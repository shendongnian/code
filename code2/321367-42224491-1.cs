    public static MinMax DoSomething(IEnumerable<int> source)
    {
        // bridge over to the observable world
        var connectable = source.ToObservable(Scheduler.Immediate).Publish();
        // express the desired result there (note: connectable is observed by multiple observers)
        var combined = connectable.Min().CombineLatest(connectable.Max(), (min, max) => new MinMax(min, max));
        // subscribe
        var resultAsync = combined.GetAwaiter();
        // unload the enumerable into connectable
        connectable.Connect();
        // pick up the result
        return resultAsync.GetResult();
    }
