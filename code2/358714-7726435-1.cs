    TimeSpan TimeAction(Action blockingAction)
    {
        StopWatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
        blockingAction();
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
