    public static class Extensions 
    {
       public static async Task ExecuteInParallel<T>(this IEnumerable<T> collection,
                                                     Func<T, Task> callback,
                                                     int degreeOfParallelism)
       {
          var queue = new ConcurrentQueue<T>(collection);
    
          var tasks = Enumerable.Range(0, degreeOfParallelism)
                                .Select(async _ =>
                                 {
                                    while (queue.TryDequeue(out var item))
                                    {
                                       await callback(item);
                                    }
                                 });
    
          await Task.WhenAll(tasks);
       }
    }
