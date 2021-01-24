    public static Task<(T[] Results, Exception[] Exceptions)> WhenAllEx<T>(params Task<T>[] tasks)
    {
        return Task.WhenAll(tasks).ContinueWith(_ => // return a continuation of WhenAll
        {
            var results = tasks
                .Where(t => t.Status == TaskStatus.RanToCompletion)
                .Select(t => t.Result)
                .ToArray();
            var aggregateExceptions = tasks
                .Where(t => t.IsFaulted)
                .Select(t => t.Exception) // The Exception is of type AggregateException
                .ToArray();
            var exceptions = new AggregateException(aggregateExceptions).Flatten()
                .InnerExceptions.ToArray(); // Trick to flatten the hierarchy of AggregateExceptions
            return (results, exceptions);
        }, TaskContinuationOptions.ExecuteSynchronously);
    }
