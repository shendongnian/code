    double usualCallTime = 1000;
    double extraDealy = 100;
    var subject = new Subject<double>();
    var subscription =
        sub.TimeInterval()
            .Select(x =>
                {
                    var processingTime = x.Interval.TotalMilliseconds - x.Value;
                    double timeToWait = 
                         Math.Max(0, usualCallTime - processingTime) + extraDelay;
                    return Observable.Timer(TimeSpan.FromMilliseconds(timeToWait))
                        .Select(ignore => timeToWait);
                })
            .Switch()
            .Subscribe(x => {YOURCODE();sub.OnNext(x)});
    sub.OnNext(0);
    private static void YOURCODE()
    {
        // do stuff here
        action.Invoke();
    }
