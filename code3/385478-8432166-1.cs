    public void MyTimerCallback(object something) {
        timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        var now = DateTime.UtcNow;
        var shouldProbablyHaveRun = new DateTime(
            now.Year, now.Month, now.Day,
            now.Hour, now.Minute - (now.Minute % 10), 0);
        var nextRun = shouldProbablyHaveRun.AddMinutes(10.0);
        // Do stuff here!
        var diff = nextRun - DateTime.UtcNow;
        timer.Change(diff, new TimeSpan(-1));
    }
