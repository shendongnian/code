    bool lockTaken = false;
    try
    {
        Monitor.Enter(syncRoot, ref lockTaken);
        // code inside of lock
    }
    finally
    {
        if (lockTaken)
            Monitor.Exit(_myObject);
    }    
