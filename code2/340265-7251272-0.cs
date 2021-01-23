    private volatile _keepRunning = true;
    public void DoWork()
    {
        while(_keepRunning)
        {
        }
    }
    public void Abort()
    {
        _keepRunning = false;
    }
