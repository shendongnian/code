    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        InitializationTest();
        Console.WriteLine($"Initialization Test time: {sw.Elapsed}");
        sw.Stop();
        
        sw.Start();
        ReflectionTest();
        Console.WriteLine($"Reflection Test time: {sw.Elapsed}");
        sw.Reset();
        Console.ReadLine();
    }
