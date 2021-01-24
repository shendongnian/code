    IObservable<Int32> obs_sync= Observable.Create<Int32>(subscribeAsync:
    (async (obsrvr) =>
    {
        Task _B = Task.Run(async () =>
        {
            while (DateTime.Now.Second % 2 != 0);
        });
         Task _AB = Task.Run(() =>
         {
            Observable.Interval(period: TimeSpan.FromMilliseconds(5E2)).Take(2);
         });
        while (!(_B.IsCompleted && _AB.IsCompleted))
        {
            await Task.Delay(TimeSpan.FromMilliseconds(15E1));
        }
    obsrvr.OnNext(0);
    }));
    Stopwatch BUSWATCH = Stopwatch.StartNew();
    obs_sync.Publish().Connect();
    Task.Run(() => obs_sync.Repeat().Take(5).Wait()).Wait();
    //Debug.WriteLine($"{nameof(DateTime.Now.Millisecond)} : {DateTime.Now.Millisecond:N2}.");
    Debug.WriteLine($"{nameof(BUSWATCH.Elapsed.TotalMilliseconds)} : {BUSWATCH.Elapsed.TotalMilliseconds:N2}.");
