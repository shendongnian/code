    public static bool AllConditions<TSource>(this IEnumerable<TSource> source,
        params Func<IObservable<TSource>, IObservable<bool>>[] conditions)
    {
        var observable = source.ToObservable();
        var connectable = observable.Replay(); // Returns a connectable observable
            // sequence that shares a single subscription to the underlying sequence
            // replaying all notifications.
        var conditionalObservables = conditions
            .Select(condition => condition(connectable));
        connectable.Connect(); // Connects the observable wrapper to its source.
            // All subscribed observers will receive values from the underlying
            // observable sequence
        var results = conditionalObservables
            .Select(o => o.ToEnumerable().Single());
        return results.All(r => r);
    }
