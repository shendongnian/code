    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            id = 1;
            coin = 3;
            diamond = 4;
            StartCoroutine (UpdateUser(id, coin, diamond));
        }
    }
