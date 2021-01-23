    public void Test()
    {
        var input = "Hello world, I'm ekk. This is test string";
    
        TestStringIndexOfPerformance(input, StringComparison.CurrentCulture);
        TestStringIndexOfPerformance(input, StringComparison.InvariantCulture);
        TestStringIndexOfPerformance(input, StringComparison.Ordinal);
    
        Console.ReadLine();
    }
    private static void TestStringIndexOfPerformance(string input, StringComparison stringComparison)
    {
        var count = 0;
        var startTime = DateTime.UtcNow;
        TimeSpan result;
        for (var index = 0; index != 1000000; index++)
        {
            count = input.IndexOf("<script", 0, stringComparison);
        }
        result = DateTime.UtcNow.Subtract(startTime);
        Console.WriteLine("{0}: {1}", stringComparison, count);
        Console.WriteLine("Total time: {0}", result.TotalMilliseconds);
        Console.WriteLine("--------------------------------");
    }
