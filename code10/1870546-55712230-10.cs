    private bool acceleratePressed;
    private bool brakePressed;
    private bool leftPressed;
    private bool rightPressed;
    public void SetAccelerate(bool pressed)
    {
        acceleratePressed = pressed;
    }
    public void SetBrake(bool pressed)
    {
        brakePressed = pressed;
    }
    public void SetRightPressed(bool pressed)
    {
        rightPressed = pressed;
    }
    public void SetLeftPressed(bool pressed)
    {
        leftPressed = pressed;
    }
    private void FixedUpdate()
    {
        if(acceleratePressed) 
        {
            rb.AddForce( transform.up * speedForce );
        }
        if(brakePressed)
        {
            rb.AddForce( transform.up * -speedForce/2f );
        }
        var leftRight = 0;
        if(leftPressed && !rightPressed)
        {
            leftRight = -1;
        }
        else if(!leftPressed && rightPressed)
        {
            leftRight = 1;
        }
        // If you are using positional wheels in your physics, then you probably
        // instead of adding angular momentum or torque, you'll instead want
        // to add left/right Force at the position of the two front tire/types
        // proportional to your current forward speed (you are converting some
        // forward speed into sideway force)
        float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2);
        rb.angularVelocity = leftRight * tf;
    }
    
