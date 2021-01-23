	public static class Extension
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var t in source)
			{
				action(t);
			}
			return source;
		}
	}
