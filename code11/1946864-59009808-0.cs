    void OnCollisionEnter (Collision col) 
    {
       if(col.gameobject.layer == LayerMask.NameToLayer("Floor") && IsGrounded())
       {
           isGrounded = true;
       }
    }
    void OnCollisionExit (Collision col) 
    {
       if(col.gameobject.layer == LayerMask.NameToLayer("Floor") && !IsGrounded())
       {
           isGrounded = false;
       }
    }
