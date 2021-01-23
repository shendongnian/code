    public void FastSubjectSubscribeTest(int iterations, Action<int> action, IScheduler scheduler, string mode)
    {
        counter = 0;
        var start = Stopwatch.StartNew();
        var observable = new ConnectableObservable<int>(CreateFastObservable(iterations), new FastSubject<int>()).RefCount();
        observable.SubscribeOn(scheduler).Run(action);
        OutputTestDuration("FastSubject.Subscribe() - " + mode, start);
    }
