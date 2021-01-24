	private async Task<string> ReturnString()
    {
		var task = Task.Run(() => 
		{
			Thread.Sleep(1500); // CPU-bound work
			_cancellationToken.ThrowIfCancellationRequested();
		});
        
        await task; // Faulted status for this task
        // but the task returned to the caller of ReturnString 
        // will be of Canceled status,
        // thanks to the compiler-generated async plumbing magic
        return "Ready";
    }
