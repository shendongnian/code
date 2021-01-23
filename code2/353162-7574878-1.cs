    Monitor.Enter(lockObj)
    try
    {
        // do stuff
    }
    finally
    {
        Monitor.Exit(lockObj)
    }
