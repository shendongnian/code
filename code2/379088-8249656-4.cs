    /// <summary>
    /// Called when it is time to setup the next frame. Add you game logic here.
    /// </summary>
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        TimeSlice();
        // handle keyboard here
        if (Keyboard[Key.Escape])
        {
            // escape key was pressed
            Exit();
        }
    }
