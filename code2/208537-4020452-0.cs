    public void Exit()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit(); // this is calling your own Exit() method we we are  in at the moment!
        }
    }
