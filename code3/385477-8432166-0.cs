    public void MyTimerCallback() {
        timer.Stop();
        var now = DateTime.UtcNow;
        var shouldProbablyHaveRun = new DateTime(
            now.Year, now.Month, now.Day,
            now.Hour, now.Minute - (now.Minute % 10), 0);
        var nextRun = shouldProbablyHaveRun.AddMinutes(10.0);
        
        // Do stuff here!
        
        var diff = nextRun - DateTime.UtcNow;
        timer.Interval = diff.TotalMilliseconds;
        timer.Start();
    }
