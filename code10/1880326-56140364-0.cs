	class Gateway : IDisposable 
	{
		protected readonly HttpClient _client = new HttpClient();  //an inner class that must be disposed when Gateway disposes
		protected bool _disposalRequested = false;
		protected bool _disposalCompleted = false;
		protected int _tasksRunning = 0;
		public void Dispose()
		{
		    Console.WriteLine("Dispose() called.");
			_disposalRequested = true;  
			if (_tasksRunning == 0)
			{
			    Console.WriteLine("No running tasks, so disposing immediately.");
				DisposeInternal();
			}
			else
			{
			    Console.WriteLine("There are running tasks, so disposal shall be deferred.");
			}
		}
		public void DisposeInternal()
		{
			if (!_disposalCompleted)
			{
				Console.WriteLine("Disposing");
				_client.Dispose();
			}
		}
		
		protected async Task<T> AddDisposeWrapper<T>(Func<Task<T>> func)
		{
			_tasksRunning++;
			var result = await func();
			_tasksRunning--;
			await DisposalCheck();
			return result;
		}
		protected async Task DisposalCheck()
		{
			if (_disposalRequested) DisposeInternal();
		}
		public Task<Data> Request1()
		{
		    return AddDisposeWrapper
			(
				Request1Internal
			);
		}
        public Task<Data> Request2()
		{
		    return AddDisposeWrapper
			(
				Request2Internal
			);
		}
		protected async Task<Data> Request1Internal()
		{
			Console.WriteLine("Performing Request1 (slow)");
			await Task.Delay(3000);
			Console.WriteLine("Request1 has finished. Returning new Data.");
			return new Data();
		}
		protected async Task<Data> Request2Internal()
		{
			Console.WriteLine("Performing Request2 (fast)");
			await Task.Delay(1);
			Console.WriteLine("Request2 has finished. Returning new Data.");
			return new Data();
		}
    }
