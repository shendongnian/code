    private static bool Foo()
    {
        if (!DoMethod1())
        {
            Console.WriteLine("DoMethod1 Failed");
            return false;
        }
        if (!DoMethod2())
        {
            Console.WriteLine("DoMethod2 Failed");
            return false;
        }
        if (!DoMethod3())
        {
            Console.WriteLine("DoMethod3 Failed");
            return false;
        }
        return true;
    }
