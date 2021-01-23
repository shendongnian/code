    task.ContinueWith(
        t => { var x = t.Exception; ...handle exception... },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnFaulted,
        TaskScheduler.FromCurrentSynchronizationContext()
    );
