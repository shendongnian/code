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
                queue.Clear();
                observer.OnError(ex);
            };
            Action<Exception> onCompleted = () =>
            {
                completing = true;
                dequeue();
            };
        
            Action dequeue = () =>
            {
                lock (queue)
                {
                    var error = false;
                    while (queue.Count > 0 && queue.Peek().First)
                    {
                        var task = queue.Dequeue();
                        observer.OnNext(task.Second);
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
                runningTasks.Add(cancellation);
    
                var task = new Tuple<bool,U>(false, default(U));
    
                cancellation.Disposable = scheduler.Schedule(() =>
                {
                    try
                    {
                        task.Second = selector(t);
    
                        lock(lockGate)
                        {
                            task.First = true;
                            runningTasks.Remove(cancellation);
                            dequeue();
                        }
                    }
                    catch(Exception ex)
                    {
                        lock(lockGate)
                        {
                            onError(ex);
                        }
                    }
                });
            };
            return new CompositeDisposable(runningTasks, 
                source.AsObservable().Subscribe(
                    t => { lock(queue) enqueue(t); },
                    x => { lock(queue) onError(x); },
                    () => { lock(queue) onCompleted(); }
                ));
        });
    }
