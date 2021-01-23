    static long Benchmark(Action action, int iterationCount, bool print = true)
    {
        GC.Collect();
        var sw = new Stopwatch();
        action(); // Execute once before
            
        sw.Start();
        for (var i = 0; i <= iterationCount; i++)
        {
            action();
        }
        sw.Stop();
        if (print) System.Console.WriteLine("Elapsed: {0}ms", sw.ElapsedMilliseconds);
        return sw.ElapsedMilliseconds;
    }
