     private object WithRetry(Func<object> method)
        {
            int tryCount = 0;
            bool done = false;
            object result = null;
            do
            {
                try
                {
                    result = method();
                    done = true;
                }
                catch (DataCacheException ex)
                {
                    if (ex.ErrorCode == DataCacheErrorCode.KeyDoesNotExist)
                    {
                        done = true;
                    }
                    else if ((ex.ErrorCode == DataCacheErrorCode.Timeout ||
                    ex.ErrorCode == DataCacheErrorCode.RetryLater ||
                    ex.ErrorCode == DataCacheErrorCode.ConnectionTerminated)
                    && tryCount < MaxTryCount)
                    {                        
                        tryCount++;
                        LogRetryException(ex, tryCount);
                    }
                    else
                    {
                        LogException(ex);
                        done = true;
                    }
                }
            }
            while (!done);
   
     return result;
    }
