    public static Task<Task<T>>[] Interleaved<T>(IEnumerable<Task<T>> tasks)
    {
       var inputTasks = tasks.ToList();
       var buckets = new TaskCompletionSource<Task<T>>[inputTasks.Count];
       var results = new Task<Task<T>>[buckets.Length];
       for (int i = 0; i < buckets.Length; i++)
       {
           buckets[i] = new TaskCompletionSource<Task<T>>();
           results[i] = buckets[i].Task;
       }
       int nextTaskIndex = -1;
       Action<Task<T>> continuation = completed =>
       {
           var bucket = buckets[Interlocked.Increment(ref nextTaskIndex)];
           bucket.TrySetResult(completed);
       };
       foreach (var inputTask in inputTasks)
           inputTask.ContinueWith(continuation, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
       return results;
    }
