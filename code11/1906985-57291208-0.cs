    boolean MouseButtonDown=false;
    void Update(){
    if(Input.GetMouseButtonDown(0)){
    MouseButtonDown=true;
    }
    }
    
    void FixedUpdate(){
    if (MouseButtonDown)
                 {
                     if(change == true)
                     {
                         rb.velocity = new Vector2(-12,rb.velocity.y);
                         change=!change;
                     }
                     else if(change == false)
                     {
                         change=!change;
                         rb.velocity = new Vector2(12,rb.velocity.y);
                     }
         }
    }
