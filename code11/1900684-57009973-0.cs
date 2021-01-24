	private static Task<MyResult> CreateTask(CancellationTokenSource cts)
	{
		return Task.Run(async () =>
		{
			var result = await TaskAction(cts.Token);
            
            // If result is false, cancel all tasks
			if (!result.Result)
				cts.Cancel();
			return result;
		});
	}
	private static async Task<MyResult> TaskAction(CancellationToken token)
	{
        if(token.IsCancellationRequested)
        {
            // The token was already cancelled
            return new MyResult
            {
                WasCancelled = true
            };
        } 
		var delay = Rnd.Next(2, 5);
		try
		{
			await Task.Delay(delay * 1000, token);
		}
		catch (TaskCanceledException)
		{
			return new MyResult
			{
				WasCancelled = true
			};
		}
		var taskResult = Rnd.Next(10) < 4;
		return new MyResult {Result = taskResult};
	}
