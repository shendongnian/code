    static void Main(string[] args)
    {
        var r = new Random(10);
        
        var testcase = Enumerable.Range(0, 400000).Select(x => r.Next(1000)).ToList();
        var sw = Stopwatch.StartNew();
        long resultCost = testcase.CostOfMerge();
        sw.Stop();
        Console.WriteLine($"Cost of Merge: {resultCost}");
        Console.WriteLine($"Time of Merge: {sw.Elapsed}");
        Console.ReadLine();
    }
