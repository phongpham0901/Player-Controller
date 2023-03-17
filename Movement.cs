using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    public float speed;
    public int jumpForce;
    bool jump = false;
    float inputX;
    bool facingRight = true;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !jump)
        {
            Jump();
            jump = true;

        }
        if(inputX < 0 && facingRight)
        {
            flip();
        }

        if (inputX > 0 && !facingRight)
        {
            flip();
        }

    }
    void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}