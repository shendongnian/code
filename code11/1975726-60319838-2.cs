    var watch = new StopWatch();
    watch.Start();
    while(...)
    {
        if (watch.Elapsed > TimeSpan.FromMinutes(15))
        {
            // do your stuff
            watch.Restart();
        }
    }
