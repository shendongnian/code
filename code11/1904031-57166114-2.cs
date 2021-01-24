    bool wasClicked;
    RigidBody playerRigidBody;
    
    void Start()
    {
        // do this only once!
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // Catch user input here
        if (Input.GetKeyDown(KeyCode.X))
        {
            wasClicked = true;
        }
    }
    
    void FixedUpdate()
    {
        // Handle physics here
        if(!wasClicked) return;
    
        playerRigidBody.position = AnotherObject.transform.position;
    
        wasClicked = false;
    }
