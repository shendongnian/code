    if (!Monitor.TryEnter(x))
    {
        Log();
        Monitor.Enter(x);
    }
    try
    {
        //do work on a collection
    }
    finally
    {
        Monitor.Exit(x);
    }
