    public void Exit()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Environment.Exit();
        }
    }
