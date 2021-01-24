    public bool isGrounded;  
    //During collisions you would still want your object to jump, such as jumping while touching the corner of a wall, so:
    void OnCollisionStay()
    {
            isGrounded = true;
    }  
    
    //Your not able to jump right after collision: (Also add layers so your object can't pass through walls or entities in the game)
    void OnCollisionExit()
    {
            isGrounded = false;
    }
    //Jump only if your object is on ground:
    void Jump()
    {
           if(isGrounded)
           {
              rb.AddForce (Vector2.up * jumpForce);
              //set it to false again so you can't multi jump:
              isGrounded = false;
           }
    }
