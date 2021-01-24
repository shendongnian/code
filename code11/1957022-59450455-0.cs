        void Update()
        {
            // Get user input
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            // Set animator paramaters
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
    
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
                //animator.SetBool("isCrouching", true); Remove this line of code
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
                //animator.SetBool("isCrouching", false); Remove this line of code
            }
        }
    
 
