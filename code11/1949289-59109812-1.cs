            if (Input.GetAxisRaw("Horizontal") > 0.5f && !facingRight)
            {
                // If we're moving right but not facing right, flip the sprite
                // and set facingRight to true.
                Flip();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight)
            {
                // If we're moving left but not facing left, flip the sprite 
                // and set facingRight to false.
                Flip();
            }
