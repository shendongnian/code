    Monitor.Enter(lockObj);
    try
    {
        // do another work (may take some time)
    }
    finally
    {
        Monitor.Exit(lockObj);
    }
