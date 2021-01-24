    private static Policy GetRetryPolicy(bool useWaitAndRetry)
        {
            if (!useWaitAndRetry)
            {
                return Policy.NoOp();
            }
            return Policy
                .Handle<Exception>()
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                });
        }
