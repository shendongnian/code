    public static IObservable<U> Fork<T, U>(this IObservable<T> source,
        Func<T, U> selector)
    {
        return source.Fork<T, U>(selector, Scheduler.TaskPool);
    }
    public static IObservable<U> Fork<T, U>(this IObservable<T> source,
        Func<T, U> selector, IScheduler scheduler)
    {
        return Observable.CreateWithDisposable<U>(observer =>
        {
            var runningTasks = new CompositeDisposable();
            var lockGate = new object();
            var queue = new Queue<ForkTask<U>>();
            var completing = false;
            var subscription = new MutableDisposable();
        
            Action<Exception> onError = ex =>
            {
                lock(lockGate)
                {
                    queue.Clear();
                    observer.OnError(ex);
                }
            };
        
            Action dequeue = () =>
            {
                lock (lockGate)
                {
                    var error = false;
                    while (queue.Count > 0 && queue.Peek().Completed)
                    {
                        var task = queue.Dequeue();
                        observer.OnNext(task.Value);
                    }
                    if (completing && queue.Count == 0)
                    {
                        observer.OnCompleted();
                    }
                }
            };
            Action onCompleted = () =>
            {
                lock (lockGate)
                {
                    completing = true;
                    dequeue();
                }
            };
            Action<T> enqueue = t =>
            {
                var cancellation = new MutableDisposable();
                var task = new ForkTask<U>();
                lock(lockGate)
                {
                    runningTasks.Add(cancellation);
                    queue.Enqueue(task);
                }
    
                cancellation.Disposable = scheduler.Schedule(() =>
                {
                    try
                    {
                        task.Value = selector(t);
    
                        lock(lockGate)
                        {
                            task.Completed = true;
                            runningTasks.Remove(cancellation);
                            dequeue();
                        }
                    }
                    catch(Exception ex)
                    {
                        onError(ex);
                    }
                });
            };
            return new CompositeDisposable(runningTasks, 
                source.AsObservable().Subscribe(
                    t => { enqueue(t); },
                    x => { onError(x); },
                    () => { onCompleted(); }
                ));
        });
    }
    private class ForkTask<T>
    {
        public T Value = default(T);
        public bool Completed = false;
    }
