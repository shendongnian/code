    public static void Test(Action a)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
    
        for (var i = 0; i < 10000; ++i)
            a();
    
        sw.Stop();
    
        Console.WriteLine("ms: {0} ticks: {1}", sw.ElapsedMilliseconds, sw.ElapsedTicks);
    }
