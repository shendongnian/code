    public static MinMax GetMinMax(IEnumerable<int> source)
    {
        // convert source to an observable that does not enumerate (yet) when subscribed to
        var connectable = source.ToObservable(Scheduler.Immediate).Publish();
        // set up multiple consumers
        var minimum = connectable.Min();
        var maximum = connectable.Max();
        // combine into final result
        var final = minimum.CombineLatest(maximum, (min, max) => new MinMax { Min = min, Max = max });
        // make final subscribe to consumers, which in turn subscribe to the connectable observable
        var resultAsync = final.GetAwaiter();
        // now that everybody is listening, enumerate!
        connectable.Connect();
        // result available now
        return resultAsync.GetResult();
    }
