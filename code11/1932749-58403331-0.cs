    private void Update()
    {
        // updating movement value when user press WASD or arrow keys
        _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Move(_movement, _speed);
    }
    public void Move(Vector3 movement, float speed)
    {
        _rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    } 
