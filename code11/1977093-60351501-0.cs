    async Task WorkerProc(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
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
