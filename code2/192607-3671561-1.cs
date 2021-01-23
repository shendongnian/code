    class IntegerListComparer : IEqualityComparer<List<int>>
    {
		#region IEqualityComparer<List<int>> Members
		public bool Equals(List<int> x, List<int> y)
		{
			bool xContainsY = y.All(i => x.Contains(i));
			bool yContainsX = x.All(i => y.Contains(i));
			return xContainsY && yContainsX;
		}
		public int GetHashCode(List<int> obj)
		{
			return 0;
		}
		#endregion
	}
