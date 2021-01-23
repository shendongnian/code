    static void Main()
    {
        ThreadPool.QueueUserWorkItem(action =>
        {
            while (TrySomeMethod() == false)
                Thread.Sleep(1000);
        });
        
        // wait here
        Console.Read();
    }
    static bool TrySomeMethod()
    {
        try
        {
             SomeMethod();
             return true;
        }
        catch
        {
             return false;
        }
    }
