    void FixedUpdate(
    {
        if (Input.GetKey(KeyCode.Q))
            rb.MoveRotation(rb.rotation + angularSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            rb.MoveRotation(rb.rotation + -angularSpeed * Time.deltaTime);
    
        rb.MovePosition(transform.position + Vector3.up * speed * Time.deltaTime);
    }
