    public readonly struct TaskWithDefaultValue<TResult>
    {
        private readonly Task<TResult> _task;
        private readonly TResult _defaultValue;
        public TaskWithDefaultValue(Task<TResult> task, TResult defaultValue)
        {
            _task = task;
            _defaultValue = defaultValue;
        }
        public Task<TResult> GetTask() => _task;
        public TaskAwaiter<TResult> GetAwaiter() => _task.GetAwaiter();
        public TaskWithDefaultValue<TResult> Ignore<TException>()
            where TException : Exception
        {
            var continuation = _task.ContinueWith(async (t, state) =>
            {
                try
                {
                    return await t.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (ex is TException) return (TResult)state;
                    throw;
                }
            }, _defaultValue, CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default).Unwrap();
            return new TaskWithDefaultValue<TResult>(continuation, _defaultValue);
        }
    }
    public static TaskWithDefaultValue<TResult> WithDefaultValue<TResult>(
        this Task<TResult> task, TResult defaultValue)
    {
        return new TaskWithDefaultValue<TResult>(task, defaultValue);
    }
