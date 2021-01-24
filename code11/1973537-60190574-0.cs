    void ListenInput()
    {
        Vector3 rightDirection = camera.right;
        Vector3 frontDirection = camera.GetForwardFromAngleY();
    
        move = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            );
    
        Vector2.ClampMagnitude(move, 1f);
    
        MoveCharacter(rightDirection * move.x);
        MoveCharacter(frontDirection * move.y);
    }
    
    void MoveCharacter(Vector3 velocity)
    {
        transform.position += velocity * Time.deltaTime * runningSpeed;
    }
