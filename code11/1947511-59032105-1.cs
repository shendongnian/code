	/// <summary>This class is thread safe, you can call methods from any thread.</summary>
	class Measures
	{
		readonly object syncRoot = new object();
		int? lastValue = null;
		readonly List<int> buffer = new List<int>();
		/// <summary>Provide a new value</summary>
		public void produce( int val )
		{
			lock( syncRoot )
			{
				lastValue = val;
				buffer.Add( val );
				Monitor.PulseAll( syncRoot );
			}
		}
		/// <summary>Get a single last value, or null if there's none currently.</summary>
		public int? getLast()
		{
			lock( syncRoot )
				return lastValue;
		}
		/// <summary>Block the calling thread waiting for the next result.</summary>
		public int getNext()
		{
			lock( syncRoot )
			{
				Monitor.Wait( syncRoot );
				return lastValue.Value;
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
