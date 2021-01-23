	/// <summary>
	///		Demo class for reader/writer lock that supports async/await.
    ///     For source, see Stephen Taub's brilliant article, "Building Async Coordination
    ///     Primitives, Part 7: AsyncReaderWriterLock".
	/// </summary>
	public class AsyncReaderWriterLockDemo
	{
		private readonly IAsyncReaderWriterLock _lock = new AsyncReaderWriterLock(); 
		public async void DemoCode()
		{			
			using(var releaser = await _lock.ReaderLockAsync()) 
			{ 
				// Insert reads here.
                // Multiple readers can access the lock simultaneously.
			}
			using (var releaser = await _lock.WriterLockAsync())
			{
				// Insert writes here.
                // If a writer is in progress, then readers are blocked.
			}
		}
	}
