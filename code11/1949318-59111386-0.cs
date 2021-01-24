    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float jumpForce;
        private float moveInput;
        private Rigidbody2D rb;
        private bool facingRight = true;
        private bool isGrounded;
        public Transform groundCheck;
        public float checkedRadius;
        public LayerMask whatIsGround;
        private int extraJumps;
        
       
        private void Start()
        {
            extraJumps = 1;
            rb = GetComponent<Rigidbody2D>();
            
        }
    
        private void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkedRadius, whatIsGround);
            moveInput = Input.GetAxisRaw("Horizontal");
    
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
    
        private void Update()
        {
            
    
            if (isGrounded == true)
            {
                extraJumps = 2;
            }
            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    
        void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
