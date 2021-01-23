    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        TargetElapsedTime = TimeSpan.FromTicks(333333);
        TouchPanel.EnabledGestures = GestureType.Tap;
    }
