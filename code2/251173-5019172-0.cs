    void DoWork()
    {
        // we'll stop after 10 minutes
        TimeSpan maxDuration = TimeSpan.FromMinutes(10);
        Stopwatch sw = Stopwatch.StartNew();
        DoneWithWork = false;
    
        while (sw.Elapsed < maxDuration && !DoneWithWork)
        {
            // do some work
            // if all the work is completed, set DoneWithWork to True
        }
    
        // Either we finished the work or we ran out of time.
    }
