    private static void Foo()
    {
        DoMehod1();
        DoMehod2();
        DoMehod3();
    }
    // ...
    try
    {
        Foo();
    }
    catch(Exception e)
    {
        Console.WriteLine(e.ToString());
        throw;
    }
