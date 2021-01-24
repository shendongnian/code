	/// <summary>This class is thread safe, you can call methods from any threads.</summary>
	class Measures
	{
		readonly object syncRoot = new object();
		int? lastValue = null;
		TaskCompletionSource<int> tcsConsumeNext = null;
		readonly List<int> buffer = new List<int>();
		/// <summary>Provide a new value</summary>
		public void produce( int val )
		{
			TaskCompletionSource<int> tcs;
			lock( syncRoot )
			{
				lastValue = val;
				buffer.Add( val );
				tcs = tcsConsumeNext;
				tcsConsumeNext = null;
			}
			tcs?.TrySetResult( val );
		}
		/// <summary>Get a single last value, or null if there's none.</summary>
		public int? getLast()
		{
			lock( syncRoot )
				return lastValue;
		}
		/// <summary>Get a task which will complete with the next value.</summary>
		public Task<int> getNext()
		{
			lock( syncRoot )
			{
				if( null == tcsConsumeNext )
				{
					// Some setup is required to make sure the producing thread doesn't run the continuations.
					tcsConsumeNext = new TaskCompletionSource<int>( TaskCreationOptions.RunContinuationsAsynchronously );
				}
				return tcsConsumeNext.Task;
			}
		}
		/// <summary>Get all measures accumulated so far.</summary>
		public List<int> getAll()
		{
			lock( syncRoot )
			{
				List<int> result = new List<int>( buffer.Count );
				result.AddRange( buffer );
				return result;
			}
		}
	}
