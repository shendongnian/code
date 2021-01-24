    public static Task<IList<T>> BufferAllAsync<T>(this IObservable<T> observable)
    {
        List<T> result = new List<T>();
        object gate = new object();
        TaskCompletionSource<IList<T>> finalTask = new TaskCompletionSource<IList<T>>();
    
        observable.Subscribe(
            value =>
            {
                lock (gate)
                {
                    result.Add(value);
                }
            },
            exception => finalTask.TrySetException(exception),
            () => finalTask.SetResult(result.AsReadOnly())
        );
    
        return finalTask.Task;
    }
