    public static IObservable<IObservable<TSource>> Window<TSource>(
        this IObservable<TSource> source, TimeSpan timeSpan, int count,
        int size, Func<TSource, int> sizeSelector)
    {
        if (timeSpan < TimeSpan.Zero && timeSpan != Timeout.InfiniteTimeSpan)
            throw new ArgumentOutOfRangeException(nameof(timeSpan));
        if (count < 1) throw new ArgumentOutOfRangeException(nameof(count));
        if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (sizeSelector == null) throw new ArgumentNullException(nameof(sizeSelector));
        return Observable.Create<IObservable<TSource>>(observer =>
        {
            Subject<TSource> currentSubject = null;
            Stopwatch stopwatch = null;
            int itemCounter = 0;
            int currentSize = 0;
            return source.Subscribe(item =>
            {
                if (currentSubject == null)
                {
                    currentSubject = new Subject<TSource>();
                    observer.OnNext(currentSubject);
                }
                if (stopwatch == null && timeSpan != Timeout.InfiniteTimeSpan)
                {
                    stopwatch = Stopwatch.StartNew();
                }
                currentSubject.OnNext(item);
                itemCounter++;
                currentSize += sizeSelector(item);
                if (itemCounter == count
                    || (stopwatch != null && stopwatch.Elapsed >= timeSpan)
                    || currentSize >= size)
                {
                    currentSubject.OnCompleted();
                    currentSubject = null;
                    if (stopwatch != null) stopwatch.Restart();
                    itemCounter = 0;
                    currentSize = 0;
                }
            }, ex =>
            {
                if (currentSubject != null) currentSubject.OnError(ex);
                observer.OnError(ex);
            }, () =>
            {
                if (currentSubject != null) currentSubject.OnCompleted();
                observer.OnCompleted();
            });
        });
    }
