	private static Task<bool> CreateTask(CancellationTokenSource cts)
	{
		return Task.Run(async () =>
		{
			var result = await TaskAction(cts.Token);
            
            // If result is false, cancel all tasks
			if (!result)
				cts.Cancel();
			return result;
		});
	}
	private static async Task<bool> TaskAction(CancellationToken token)
	{
        // Check for cancellation
		token.ThrowIfCancellationRequested();
			
		var delay = Rnd.Next(2, 5);
        // Pass the cancellation token to Task.Delay()
		await Task.Delay(delay * 1000, token);
		var taskResult = Rnd.Next(10) < 4;
		
        // Check for cancellation
		token.ThrowIfCancellationRequested();
		
		return taskResult;
	}
