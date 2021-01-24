    IsFixedTimeStep = true;
    
    TargetElapsedTime = TimeSpan.FromTicks(208333); // 48fps (will be halved to 24fps).
    
    // The following effectively halves the frame rate to 24fps by syncing every other refresh.
    graphics.PreparingDeviceSettings += (sender, e) =>
    {
        e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Two;
    };
