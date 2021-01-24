    private void Update()
    {
        // updating movement value when user press WASD or arrow keys
        _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        bool shouldMove = Mathf.Abs(_movement.x) > Mathf.Epsilon 
                || Mathf.Abs(_movement.y) > Mathf.Epsilon; 
        if (shouldMove) Move(_movement, _speed); 
    }
    public void Move(Vector3 movement, float speed)
    {
        _rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    } 
