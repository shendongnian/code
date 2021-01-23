    public class ListComparer<T> : IEqualityComparer<List<T>>
		where T : IComparable<T>
	{
		public bool Equals(List<T> x, List<T> y)
		{
			return x.OrderBy(u => u).SequenceEqual(y.OrderBy(u => u));
		}
		public int GetHashCode(List<T> obj)
		{
			return obj.GetHashCode();
		}
	}
