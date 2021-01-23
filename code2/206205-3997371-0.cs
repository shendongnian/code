    public static class IEnumerableExtensions
	{
		public static T2 ToListContainer<T1, T2>(this IEnumerable<T1> list) where T2: List<T1>, new()
		{
			T2 listContainer = new T2();
			listContainer.AddRange(list);
			return listContainer;
		}
		
	}
