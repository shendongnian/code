    public static long Time(Action action)
    {
       var stopWatch =  Stopwatch.StartNew();
       action();
       return stopWatch.ElapsedMilliseconds;
    }
