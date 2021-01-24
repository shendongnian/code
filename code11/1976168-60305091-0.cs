	public static IEnumerable<T> ReplaceWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate, T substitute)
	{
		var zerosLength = source.TakeWhile(predicate).Count();
		return Enumerable.Repeat(substitute, zerosLength).Concat(source.Skip(zerosLength));
	}
