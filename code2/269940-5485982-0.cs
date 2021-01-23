	public static void AddAll<T>(this ICollection<T> c, IEnumerable<T> items)
	{
		items.ForEach(item => c.Add(item));
	}
	public static void AddAll<T1, T2>(this ICollection<T1> c, IEnumerable<T2> items, Func<T2, T1> converter)
	{
		c.AddAll(items.Select(converter));
	}
	public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
	{
		foreach (T item in e)
			action.Invoke(item);
	}
