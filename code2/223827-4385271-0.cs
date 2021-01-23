    protected override void Update(GameTime gameTime)
    {
        updateFrameStart.Set();
        updateFrameEnd.WaitOne();
    }
    
    public void UpdateThreadRoutine()
    {
        while (!timeToQuit)
        {
            updateFrameStart.WaitOne();
            //--> Doing all Updating stuff here <--
            updateFrameEnd.Set();
        }
    }
