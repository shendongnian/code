    public void SimpleObserveTest(int iterations, Action<int> action, IScheduler scheduler, string mode)
    {
        counter = 0;
        var start = Stopwatch.StartNew();
        Observable.Create<int>(observer =>
        {
            new Thread(_ =>
            {
                for (int i = 0; i < iterations; i++)
                {
                    observer.OnNext(i);
                }
                observer.OnCompleted();
            }).Start();
            return () => { };
        }).SubscribeOn(scheduler).Run(action);
        OutputTestDuration("Simple - " + mode, start);
    }
