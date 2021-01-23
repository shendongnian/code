    public void FastSubjectSubscribeTest(int iterations, Action<int> action, IScheduler scheduler, string mode)
    {
        counter = 0;
        var start = Stopwatch.StartNew();
        var o = new ConnectableObservable<int>(CreateFastObservable(iterations), new FastSubject<int>()).RefCount();
        o.SubscribeOn(scheduler).Run(action);
        OutputTestDuration("FastSubject.Subscribe() - " + mode, start);
    }
