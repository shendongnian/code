    public static IEnumerable<IEnumerable<T>> SplitWhen<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        yield return enumerable.TakeWhile(predicate);
		yield return enumerable.TakeAfter(predicate);
    }
	
	public static IEnumerable<T> TakeAfter<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
	{
		bool yielding = false;
		foreach (T item in enumerable)
		{
			if (yielding = yielding || !predicate(item))
			{
				yield return item;
			}
		}
	}
