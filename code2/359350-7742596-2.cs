    bool lockTaken = false;
    var obj = x;
    try
    {
        Monitor.TryEnter(obj, ref lockTaken);
        if (!lockTaken)
        {
            Log();
            Monitor.Enter(obj, ref lockTaken);
        }
        //do work on a collection
    }
    finally
    {
        if (lockTaken)
        {
            Monitor.Exit(obj);
        }
    }
