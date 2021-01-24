    public virtual Task<T> ScheduleWithRetry<T>(string name, string version, RetryOptions retryOptions, params object[] parameters)
    {
        Task<T> RetryCall() => ScheduleTask<T>(name, version, parameters);
        var retryInterceptor = new RetryInterceptor<T>(this, retryOptions, RetryCall);
        return retryInterceptor.Invoke();
    }
