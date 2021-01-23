    var temp = obj;
    Monitor.Enter(temp);
    try
    {
       body
    }
    finally
    {
        Monitor.Exit(temp);
    }
