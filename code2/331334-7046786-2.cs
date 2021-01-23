    public App()
    {
        // Other stuff
        // End
        this.ApplicationLifetimeObjects.Add(new XNAAsyncDispatcher(TimeSpan.FromMilliseconds(50)));
    }
