    class MyClass : IDisposable
	{
		public void Dispose()
		{
			Dispose(true);
		}
		private void Dispose(bool disposing)
		{
			// release ...
		}
		~MyClass()
		{
			Dispose(false);
		}
	}
