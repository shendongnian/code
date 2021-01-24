	public class IEnumerableComparer<TEnumerable, TElement> : IEqualityComparer<TEnumerable> where TEnumerable : IEnumerable<TElement>
	{
		//Adapted from IEqualityComparer for SequenceEqual
		//https://stackoverflow.com/questions/14675720/iequalitycomparer-for-sequenceequal
		//Answer https://stackoverflow.com/a/14675741 By Cédric Bignon https://stackoverflow.com/users/1284526/c%C3%A9dric-bignon 
		public bool Equals(TEnumerable x, TEnumerable y)
		{
			return Object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
		}
		public int GetHashCode(TEnumerable obj)
		{
			// Will not throw an OverflowException
			unchecked
			{
				return obj.Where(e => e != null).Select(e => e.GetHashCode()).Aggregate(17, (a, b) => 23 * a + b);
			}
		}
	}
