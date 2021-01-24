    private Rigidbody rb;
    
    Start()
    {
        rb = getComponent<Rigidbody>();
    }
    Update ()
    {
        if(rb.velocity.y < 0)
        {
            // do your stuff
        }
    }
