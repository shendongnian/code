    public static IObservable<T> Concat<T>(this IObservable<IObservable<T>> source)
    {
        return Observable.CreateWithDisposable<T>(o =>
        {
            var lockCookie = new Object();
            bool completed = false;
            bool subscribed = false;
            var waiting = new Queue<IObservable<T>>();
            var pendingSubscription = new MutableDisposable();
            Action<Exception> errorHandler = e =>
            {
                o.OnError(e);
                pendingSubscription.Dispose();
            };
            Func<IObservable<T>, IDisposable> subscribe = null;
            subscribe = (ob) =>
            {
                subscribed = true;
                return ob.Subscribe(
                    o.OnNext,
                    errorHandler,
                    () =>
                    {
                        lock (lockCookie)
                        {
                            if (waiting.Count > 0)
                                pendingSubscription.Disposable = subscribe(waiting.Dequeue());
                            else if (completed)
                                o.OnCompleted();
                            else
                                subscribed = false;
                        }
                    }
                );
            };
            return new CompositeDisposable(pendingSubscription,
                source.Subscribe(
                    n =>
                    {
                        lock (lockCookie)
                        {
                            if (!subscribed)
                                pendingSubscription.Disposable = subscribe(n);
                            else
                                waiting.Enqueue(n);
                        }
                    },
                    errorHandler
                    , () =>
                    {
                        lock (lockCookie)
                        {
                            completed = true;
                            if (!subscribed)
                                o.OnCompleted();
                        }
                    }
                )
            );
        });
    }
