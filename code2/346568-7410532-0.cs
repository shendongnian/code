	public sealed class AnonymousDisposable : IDisposable
	{
		private readonly Action _dispose;
		private int _isDisposed;
	
		public AnonymousDisposable(Action dispose)
		{
			_dispose = dispose;
		}
	
		public void Dispose()
		{
			if (Interlocked.Exchange(ref _isDisposed, 1) == 0)
			{
				_dispose();
			}
		}
	}
