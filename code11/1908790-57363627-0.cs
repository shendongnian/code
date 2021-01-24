    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > 0.5)
        {
            Debug.Log("Velocity magnitude = " + rigidbody2D.velocity.magnitude);
            time = 0;
        }
    
        if (Input.GetKey(KeyCode.Q))
        {
            rigidbody2D.AddForce(speedMultiplier * Time.fixedTime * Vector2.right, ForceMode2D.Force);
        }
    }
