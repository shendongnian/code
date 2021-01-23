    Stopwatch watch = StopWatch.StartNew();
    for (int index = 0; index < 1000; index++)
    {
        SomeFunc(input);
    }
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
