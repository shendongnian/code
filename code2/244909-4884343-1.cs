    public static IObservable<U> Fork<T, U>(this IObservable<T> source,
        Func<T, U> selector)
    {
        return source.Fork(Scheduler.TaskPool);
    }
    public static IObservable<U> Fork<T, U>(this IObservable<T> source,
        Func<T, U> selector, IScheduler scheduler)
    {
        return Observable.CreatWithDisposable<U>(observer =>
        {
            var runningTasks = new CompositeDisposable();
            var lockGate = new object();
            var queue = new Queue<Tuple<bool,U>>();
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
            Action<Exception> onCompleted = () =>
            {
                lock(lockGate)
                {
                    completing = true;
                    dequeue();
                }
            };
        
            Action dequeue = () =>
            {
                lock (lockGate)
                {
                    var error = false;
                    while (queue.Count > 0 && queue.Peek().Item1)
                    {
                        var task = queue.Dequeue();
                        observer.OnNext(task.Item2);
                    }
                    if (completing && queue.Count == 0)
                    {
                        observer.OnCompleted();
                    }
                }
            };
            Action<T> enqueue = t =>
            {
                var cancellation : MutableDisposable = new MutableDisposable();
                var task = new Tuple<bool,U>(false, default(U));
                lock(lockGate)
                {
                    runningTasks.Add(cancellation);
                    queue.Enqueue(task);
                }
    
                cancellation.Disposable = scheduler.Schedule(() =>
                {
                    try
                    {
                        task.Item2 = selector(t);
    
                        lock(lockGate)
                        {
                            task.Item1 = true;
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
