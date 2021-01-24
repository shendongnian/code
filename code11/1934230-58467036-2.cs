    public static Task<TResult> Ignore<TResult>(this Task<TResult> self, TResult defaultValue, params Type[] typesToIgnore)
    {
        return self.ContinueWith(
            task =>
            {
                if (!task.IsFaulted)
                {
                    return task.Result;
                }
    
                if (typesToIgnore.Any(t => task.Exception.InnerException.GetType() == t ||
                                    task.Exception.InnerException.GetType().IsSubclassOf(t)))
                {
                    return defaultValue;
                }
    
                throw task.Exception.InnerException;
            }, TaskContinuationOptions.ExecuteSynchronously);
    }
