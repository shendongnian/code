public static class Extensions
{
	public static IEnumerable<Tuple<T, T, T>> GetItems<T>(this IEnumerable<T> source)
		where T : class
	{
		if (source != null)
		{
            // skip the first iteration to be able to include next item
			bool skip = true;
			T previous = default(T), current = default(T), next = default(T);
			foreach (T item in source)
			{
				next = item;
				if (!skip)
				{
					yield return new Tuple<T, T, T>(previous, current, next);
				}
				previous = current;
				current = item;
				skip = false;
			}
			next = default(T);
			if (!skip)
			{
				yield return new Tuple<T, T, T>(previous, current, next);
			}
		}
	}
}
Hope it helps. Maybe extend with custom class instead of tuple.
