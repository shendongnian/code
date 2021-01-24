    private void Update()
    {
        Vector2 mi = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mv = mi.normalized * speed;
        if(Input.GetKey(KeyCode.X) && energy > 0)
        {
            // Reduce energy by decreaseSpeed per second
            energy -= decreaseSpeed * Time.deltaTime;
            // if needed avoid negative value
            energy = Mathf.Max(0, energy);
            // double the move distance
            mv *= 2;
        }
    }
