    const int NUM_TASKS = 4;
    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken ct = cts.Token;
    Task[] tasks = new Task[NUM_TASKS];
    for (int i = 0; i < NUM_TASKS; i++)
    {
        tasks[i] = Task.Factory.StartNew(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (ct.IsCancellationRequested)
                    break;
            }
        }, ct);
    }
    Task.WaitAll(tasks);
