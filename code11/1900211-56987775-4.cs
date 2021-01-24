    public static class FutureExtensions
    {
        public static Task<T> ToAsync<T>(this IFuture<T> future)
        {
            var asyncResult = new AsyncResult<T>(future);
            var task = Task.Factory.FromAsync(asyncResult, x =>
            {
                var ar = (AsyncResult<T>)x;
                if (ar.Error != null)
                {
                    throw new AggregateException("Task failed.", ar.Error);
                }
    
                return ar.Result;
            });
    
            return task;
        }
    }
