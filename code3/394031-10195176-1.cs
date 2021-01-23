    Stopwatch sw = new Stopwatch();
    sw.Start(); // To initialize
    for (int i = 0; i < 100; i++)
    {
        sw.Restart();
        // Business logic 
        TimeSpan time = sw.Elapsed;
        // Save timespan in log file
    }
