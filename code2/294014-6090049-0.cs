    public static Func<T> Retry(Func<T> original, int retryCount)
    {
        return () =>
        {
            while (true)
            {
                try
                {
                    return original();
                }
                catch (Exception e)
                {
                    if (retryCount == 0)
                    {
                        throw;
                    }
                    // TODO: Logging
                    retryCount--;
                }
            }
        };
    }
