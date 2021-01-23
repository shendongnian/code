    LockObject _lockObj = new LockObject();
    
    public void obtainLock()
    {
        _lockObj.Lock();
        // doStuff
    }
    
    public void obtainReleaseLock()
    {
        using(_lockObj.Lock())
        {
            // doAnotherStuff
        }
    }
