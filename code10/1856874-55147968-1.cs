    public float movementSpeed= 5f; //for instance
 
    void FixedUpdate()
    {
     
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
        rigidbody.MovePosition(transform.position + direction * movementSpeed * Time.fixedDeltaTime);
    }
