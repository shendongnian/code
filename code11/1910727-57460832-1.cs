	public class HistogramComparer : IEqualityComparer<Dictionary<int, int>>
	{
		public bool Equals(Dictionary<int, int> x, Dictionary<int, int> y)
		{
			// check that y contains all x.Keys
			foreach (var key in x.Keys)
				if (!y.Keys.Contains(key))
					return false;
			// check that x contains all y.Keys
			foreach (var key in y.Keys)
				if (!x.Keys.Contains(key))
					return false;
			
			// check that keys have same values
			foreach (var entry in x)
				if (y[entry.Key] != entry.Value)
					return false;
			
			return true;
		}
		
		public int GetHashCode(Dictionary<int, int> obj)
		{
			int hash = 0;
			foreach (var entry in obj)
				hash ^= (entry.Key ^ entry.Value);
			
			return hash;
		}
	}
