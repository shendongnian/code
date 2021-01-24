void Update()
    {
        if (joystick.Horizontal >= .1f || joystick.Horizontal <= -.1f)
        {
            movement.x = joystick.Horizontal;
            MoveCharacter();
        }
        else
        {
            movement.x = 0f;
            angle = 0f;
        }
        if (joystick.Vertical >= .1f || joystick.Vertical <= -.1f)
        {
            movement.y = joystick.Vertical;
            MoveCharacter();
        }
        else
        {
            movement.y = 0f;
            angle = 0f;
        }
    }
    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
Hopefully this may help someone that might have the same problem. I doubt anyone would have the same problem but I hope it helps. :D
