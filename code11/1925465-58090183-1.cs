    void JumpHandler()
    {
    
        float jAxis = Input.GetAxis("Jump");
        float jumpValue = 0f;
    
        //if pressed
        if (jAxis > 0)
        {
            bool isGrounded = CheckGrounded();
    
            if (isGrounded)
            {
                jumpValue = jAxis; 
                if (!jumpPressed)
                {
                    jumpPressed = true; //Pressed jump
                }
            }
            else
            {
                jumpValue = 0;
            }
        }
        if (jumpPressed)
        {
            rb.AddForce(
                    //Absolute value to prevent weird cases of negative jAxis
                    new Vector3(0, Mathf.Abs(jumpValue) * jumpForce * 1, 0),
                    ForceMode.VelocityChange);
            //jump key not pressed
            jumpValue = 0;
            jumpPressed = false;
        }
    }
