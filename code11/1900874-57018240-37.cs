    public async Task<ReturnsMessage> FunctionAsync()
    {
      using (var cancellationTokenSource = new CancellationTokenSource())
      {
        try
        {
          var task = Task.Run(
            () =>
            {
              // Check if the task needs to be cancelled
              // because the timeout task ran to completion first
              cancellationToken.ThrowIfCancellationRequested();
    
              var result = SyncMethod();
              return result;
            }, cancellationTokenSource.Token);
    
          int delay = 500;
          Task timoutTask = Task.Delay(delay, cancellationTokenSource.Token);
          Task firstCompletedTask = await Task.WhenAny(task, timoutTask);
    
          if (firstCompletedTask == task)
          {
            // The 'task' has won the race, therefore
            // cancel the 'timeoutTask'
            cancellationTokenSource.Cancel();
            return await task;
          }
        }
        catch (OperationCanceledException)
        {}
    
        // The 'timeoutTask' has won the race, therefore
        // cancel the 'task' instance
        cancellationTokenSource.Cancel();
    
        var tcs = new TaskCompletionSource<string>();
        tcs.SetCanceled();
        return await tcs.Task;
      }
    }
