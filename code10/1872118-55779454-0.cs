    private Policy GetRetryPolicy()
        {
            if (!this.config.DistributedLockEnabled)
            {
                return Policy.NoOp();
            }
            return Policy
                .Handle<TimeoutException>()
                .OrResult<IDisposable>(d => d == null)
                .WaitAndRetry(
                    this.config.WorkflowLockHandleRequestRetryAttempts,
                    attempt => TimeSpan.FromSeconds(this.config.WorkflowLockHandleRequestRetryMultiplier * Math.Pow(this.config.WorkflowLockHandleRequestRetryBase, attempt)),
                    (delegateResult, calculatedWaitDuration, attempt, context) =>
                    {
                        if (delegateResult.Exception != null)
                        {
                            this.logger.Information(
                                "Exception {0} attempt {1} delaying for {2}ms",
                                delegateResult.Exception.Message,
                                attempt,
                                calculatedWaitDuration.TotalMilliseconds);
                        }
                    });
        }
