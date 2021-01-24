    async Task WorkerProc(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Func<Task> action;
            if (_highPriorityQueue.TryDequeue(out action))
            {
                await action();
                continue;
            }
            if (_lowPriorityQueue.TryDequeue(out action))
            {
                await action();
                continue;
            }
            await Task.Yield();
        }
    }
