    TimeSpan TimeAction(Action blockingAction)
    {
        Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
        blockingAction();
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
