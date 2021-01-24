    public static Task<TResult> Ignore<TResult>(this Task<TResult> self, TResult defaultValue, params Type[] typesToIgnore)
    {
    	return self.ContinueWith(
    		task => {
    			if (typesToIgnore.Any(t => task.Exception.InnerException.GetType().IsSubclassOf(t)))
    			{				
    				return defaultValue;
    			}
    
    			throw task.Exception.InnerException;
    		}, 
    		TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
    }
