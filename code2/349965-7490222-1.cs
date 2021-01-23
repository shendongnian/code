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
                    // Swallowing exceptions is BAD, BAD, BAD. You should AT LEAST log it.
                }
            }
        }
        public void RetryUntilSuccess(Action action) 
        {
            // Trick to allow a void method being passed in without duplicating the implementation.
            RetryUntilSuccess(() => { action(); return true; });
        }
    }
