	/// <summary>
	/// Adds only items that do not exist in source.  May be very slow for large collections and some types of source.
	/// </summary>
	/// <typeparam name="T">Type in the collection.</typeparam>
	/// <param name="source">Source collection</param>
	/// <param name="predicate">Predicate to determine whether a new item is already in source.</param>
	/// <param name="items">New items.</param>
	public static void AddUniqueBy<T>(this ICollection<T> source, Func<T, T, bool> predicate, IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			bool existsInSource = source.Where(s => predicate(s, item)).Any();
			if (!existsInSource) source.Add(item);
		}
	}
