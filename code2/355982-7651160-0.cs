    private readonly object sharedMonitor;
    private bool shouldStop;
    public void Stop()
    {
        lock (sharedMonitor)
        {
            shouldStop = true;
            Monitor.Pulse(sharedMonitor);
        }
    }
    public void Loop()
    {
        while (true)
        {
            // Do some work...
            lock (sharedLock)
            {
                if (shouldStop)
                {
                    return;
                }
                Monitor.Wait(sharedLock, 10000);
                if (shouldStop)
                {
                    return;
                }
            }
        }
    }
