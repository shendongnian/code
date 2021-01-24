    private bool acceleratePressed;
    private bool brakePressed;
    public void SetAccelerate(bool pressed)
    {
        acceleratePressed = pressed;
    }
    public void SetBrake(bool pressed)
    {
        brakePressed = pressed;
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
    }
    
