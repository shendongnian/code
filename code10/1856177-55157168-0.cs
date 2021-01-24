    public static RetryPolicy LinearRetry(int retryCount, TimeSpan intervalBetweenRetries)
    {
          return () =>
          {
               return (int currentRetryCount, Exception lastException, out TimeSpan retryInterval) =>
               { 
                   // Do custom work here               
                   // Set backoff
                   retryInterval = intervalBetweenRetries;    
                   // Decide if we should retry, return bool
                   return currentRetryCount < retryCount;          
                   
               };
          };
    }
