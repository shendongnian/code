    TimeSpan TimeAction(Action blockingAction)
    {
        StopWatch stopWatch = new System.Diagnostics.Stopwatch.StartNew();
        blockingAction();
        stopWatch.Stop();
        return stopWatch.Elapsed;
    }
