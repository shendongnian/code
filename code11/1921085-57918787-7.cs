    private Vector3 movement;
    void Update()
    {
        Jump();
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    }
    private void FixedUpdate ()
    {
        rigidbody.MovePosition(rigidbody.position += movement * Time.deltaTime * moveSpeed);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(new Vector3(0f, 5f), ForceMode2D.Impulse);
        }
    }
