    // you usually need a lot of iterations to get a stable and accurate measurement
    int iterations = 10000;
    Stopwatch stopwatch = Stopwatch.StartNew();
    
    // It is important to do as little as possible between starting the
    // stopwatch and calling your function. If you need to allocate memory
    // or do any startup actions, do them before you start.
    for (int i = 0; i < iterations; ++i)
    {
        YourFunction();
    }
    
    // Similarly, don't do anything more after your code is done, just get
    // the elapsed time immediately.
    TimeSpan totalDuration = stopwatch.Elapsed;
    TimeSpan durationForEachIteration =
        TimeSpan.FromTicks(totalDuration.Ticks / iterations);
