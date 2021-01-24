    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class playercontrols : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask whatIsGround;
        private bool onGround;
    
        // Start is called before the first frame update
        void Start()
        {
          rb= GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void Update()
        {
    
          rb.velocity = new Vector2(1, rb.velocity.y);
          onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
          if (Input.GetMouseButtonDown(0) && onGround)
          {
            rb.velocity = new Vector2(rb.velocity.x, 3);
          }
        }
    }
