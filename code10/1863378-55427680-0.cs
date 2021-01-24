    private bool _jumping;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jumping = true;
        else if (Input.GetKeyUp(KeyCode.Space))
            _jumping = false;
    }
    void FixedUpdate()
    {
         if (_jumping) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
