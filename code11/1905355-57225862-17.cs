    //put your shooting scripts name below.
    private ShootScript shootScript; 
        
    void start()
    {    
        
        shootScript = GetComponent<ShootScript>();
       
    }
    void Movement()
    {
        shootScript.isMoving = true; 
    
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") 
                            * WalkSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") 
                            * WalkSpeed * Time.deltaTime);
        
        // GetKey is true on every frame that shift is held down, and false when it isn't
        // GetKeyDown is only true on the first frame in a row that shift is held down    
        if (Input.GetKey(KeyCode.LeftShift))
        {
            WalkSpeed = RunSpeed;
        }
        else 
        {
            WalkSpeed = DefaultSpeed;
        }
    }
