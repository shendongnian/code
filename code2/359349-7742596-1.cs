    bool lockTaken = false;
    try
    {
        Monitor.TryEnter(x, ref lockTaken);
        if (!lockTaken)
        {
            Log();
            Monitor.Enter(x, ref lockTaken);
        }
        //do work on a collection
    }
    finally
    {
        if (lockTaken)
        {
            Monitor.Exit(x);
        }
    }
