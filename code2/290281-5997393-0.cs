    System.Threading.Monitor.Enter(x);
    try {
       ...
    }
    catch(Exception e)
    {
    }
    finally {
       System.Threading.Monitor.Exit(x);
    }
