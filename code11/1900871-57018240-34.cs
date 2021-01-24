    public async Task<ReturnsMessage> FunctionAsync()
    {
      var timeout = 50;
      using (var timeoutCancellationTokenSource = new CancellationTokenSource(timeout))
      {
        try
        {
          return await Task.Run(
            () =>
            {
              // Check if the timeout elapsed
              timeoutCancellationTokenSource.Token.ThrowIfCancellationRequested();
              var result = SyncMethod();
              return result;
            }, timeoutCancellationTokenSource.Token);
        }
        catch (OperationCanceledException)
        {
          var tcs = new TaskCompletionSource<string>();
          tcs.SetCanceled();
          return await tcs.Task;
        }
      }
    }
