    [Test]
    public void WebRequest_Should_Get_Html_Quickly()
    {
        private const int TestIterations = 10;
        private const int MaxMilliseconds = 100;
        Action test = () =>
        {
           WebRequest.Create("http://localhost/iisstart.htm").GetResponse();
        };
        AssertTimedTest(TestIterations, MaxMilliseconds, test);
    }
    private static void AssertTimedTest(int iterations, int maxMs, Action test)
    {
        Console.WriteLine("JIT:{0:F2}ms.", Execute(test));
        Console.WriteLine("Optimize:{0:F2}ms.", Execute(test));
        double totalElapsed = 0;
        for (int i = 0; i < iterations; i++) totalElapsed += Execute(test);
        double averageMs = (totalElapsed / iterations);
        Console.WriteLine("Average:{0:F2}ms.", averageMs);
        Assert.Less(averageMs, maxMs, "Average elapsed test time.");
    }
    private static double Execute(Action action)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        action();
        return stopwatch.Elapsed.TotalMilliseconds;
    }
