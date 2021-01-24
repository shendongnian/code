    using System.Reactive.Linq;
    using System.Reactive.Concurrency;
    public static IEnumerable<T> Merge<T>(params IEnumerable<T>[] sources)
    {
        IEnumerable<IObservable<T>> observables = sources
            .Select(source => source.ToObservable(NewThreadScheduler.Default));
        IObservable<T> merged = Observable.Merge(observables);
        return merged.ToEnumerable();
    }
