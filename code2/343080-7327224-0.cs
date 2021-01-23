    public int KeyboardChecker()
    {
        while (true)
        {
            if (KeyHasBeenPressed())
            {
                HandleKeyPress();
            }
        }
    }
