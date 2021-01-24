     private void FixedUpdate()
        {
            Move(); 
        }
    protected virtual void Move()
    {
        if(randNum == 1) {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if(randNum == 2) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }
