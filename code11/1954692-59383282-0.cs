    bool spacePressed = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spacePressed)
            {
                print("Space pressed twice");
                spacePressed = false;
            }
            else
            {
                print("Space pressed once");
                spacePressed = true;
            }
        }
    }
