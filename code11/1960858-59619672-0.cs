    Camera mainCam;
    public CharacterController controller;
    public float speed = 12f;
    
    void Awake()
    {
        mainCam = Camera.main; // expensive operation, so cache the results
    }
    
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    
        Vector3 move = mainCam.transform.right * x + mainCam.transform.forward * z;
    
        // normalize move if has a magnitude > 1 to prevent faster diagonal movement
        if (move.sqrMagnitude > 1)
        {
            move.Normalize();
        }
    
        controller.Move(move * speed * Time.deltaTime);
    }
