    bool isCollision;
    
    void FixedUpdate()
    {
        if(!isCollision)
        {
            //blah blah blah
        }
    }
    void OnCollisionEnter()
    {
        isCollision = true;
    }
    
    void OnCollisionExit()
    {
        isCollision = false;
    }
