    public static async Task<TResult> Ignore<TResult>
            (this Task<TResult> task, TResult defaultValue, params Type[] typesToIgnore)
            {
                try
                {
                    return await task;
                }
                catch (Exception ex)
                {
                    if (typesToIgnore.Any(type => type.IsAssignableFrom(ex.GetType())))
                    {
                        return defaultValue;
                    }
    
                    throw;
                }
            }
