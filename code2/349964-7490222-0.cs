    public static class RetryUtility 
    {
        public T RetryUntilSuccess<T>(Func<T> action) 
        {
            while(true) 
            {
                try 
                {
                    return action();
                }
                catch 
                {
                    // Swallowing exceptions is BAD. You should AT LEAST log it.
                }
            }
        }
    }
