    static void Main(string[] args)
    {
        var d1 = new Dictionary<string, int>();
        var d2 = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        d1.Add("FOO", 1);
        d2.Add("FOO", 1);
        Stopwatch s = new Stopwatch();
        s.Start();
        RunTest1(d1, "foo");
        s.Stop();
        Console.WriteLine("ToUpperInvariant: {0}", s.Elapsed);
        s.Reset();
        s.Start();
        RunTest2(d2, "foo");
        s.Stop();
        Console.WriteLine("OrdinalIgnoreCase: {0}", s.Elapsed);
        Console.ReadLine();
    }
    static void RunTest1(Dictionary<string, int> values, string val)
    {
        for (var i = 0; i < 10000000; i++)
        {
            values[val.ToUpperInvariant()] = values[val.ToUpperInvariant()];
        }
    }
    static void RunTest2(Dictionary<string, int> values, string val)
    {
        for (var i = 0; i < 10000000; i++)
        {
            values[val] = values[val];
        }
    }
    // ToUpperInvariant: 00:00:04.5084119
    // OrdinalIgnoreCase: 00:00:02.1211549
    // 2x faster.
