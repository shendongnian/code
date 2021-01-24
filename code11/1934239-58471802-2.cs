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
            var continuation = GetContinuation(_task, _defaultValue);
            return new TaskWithDefaultValue<TResult>(continuation, _defaultValue);
            async Task<TResult> GetContinuation(Task<TResult> t, TResult dv)
            {
                try
                {
                    return await t.ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    if (ex is TException) return dv;
                    throw;
                }
            }
        }
    }
    public static TaskWithDefaultValue<TResult> WithDefaultValue<TResult>(
        this Task<TResult> task, TResult defaultValue)
    {
        return new TaskWithDefaultValue<TResult>(task, defaultValue);
    }
