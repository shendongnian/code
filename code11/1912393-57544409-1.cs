    static bool StoreFirstException(Exception x, Action<Exception> store)
    {
        if (x.Message == "Exception 1")
        {
            store(x);                
        }
        return true;
    }
    static void Method1()
    {
        Exception firstException = null;
        try
        {
            FixedUnalterableMethod(); //line 24.
        }
        catch (Exception ex) when (StoreFirstException(ex, x => firstException = x))
        {
            Console.WriteLine(firstException);               
            Console.WriteLine(ex);
        }
    }
