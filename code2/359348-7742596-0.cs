    bool lockTaken = false;
    var obj = x;
    try
    {
        Montitor.TryEnter(obj, ref lockTaken);
        if (!lockTaken)
        {
            Log();
            Montor.Enter(obj, ref lockTaken);
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
