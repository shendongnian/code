    void processTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (!Monitor.TryEnter(_timerLock))
        {
            // something has the lock. Probably shutting down.
            return;
        }
        try
        {
            // Do something here that takes ~30 seconds
        }
        finally
        {
            Monitor.Exit(_timerLock);
        }
    }
