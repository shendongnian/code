    private static void AllocateInLoop()
    {
        Func<int, int> func = null;
        int x = 10;
        Stopwatch stopwatch = Stopwatch.StartNew();
        int sum = 0;
        for (int i = 0; i < Iterations; i++)
        {
            if (func == null)
            {
                func = y => y + x;
            }
            sum += Apply(i, func);
        }
        stopwatch.Stop();
        Console.WriteLine("Allocated in loop: {0}ms", stopwatch.ElapsedMilliseconds);
    }
