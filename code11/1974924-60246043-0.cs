    public async Task SomeMethodAsync()
    {
        SomeChanged?.Invoke();
        Delegate[] delegates = SomeChangedAsync?.GetInvocationList();
        if (delegates != null)
        {
            var taskFactories = delegates.Cast<Func<Task>>().ToArray();
            foreach (var taskFactory in taskFactories)
            {
                var task = taskFactory();
                await task;
            }
        }
    }
