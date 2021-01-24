    private void FixedUpdate()
    {
        jumpButton = GameObject.Find("Jump").GetComponent<Button>();
        jumpButton.onClick.AddListener(Jump);
    
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    
        MoveInput = SimpleInput.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * speed, rb.velocity.y);
    
        if (isGrounded && jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce/rb.mass);
            jump = false;
        }
    }
