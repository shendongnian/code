    dynamic d = 5;
    try
    {
        Console.WriteLine(d.FakeMethod(4));
    }
    catch(RuntimeBinderException)
    {
        Console.WriteLine("Method doesn't exist");
    }
