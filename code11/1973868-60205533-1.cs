    StopWatch myWatch = new StopWatch();
    myWatch.Start();
    //...
    myWatch.End();
    TimeSpan ts = stopWatch.Elapsed;
    string productiveTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);
