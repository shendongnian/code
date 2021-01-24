	public static IEnumerable<string> Join<T>(this IEnumerable<T> list,
		string separator,
		params Func<T, string>[] properties) where T : class
	{
		foreach (var element in list)
		{
			yield return string.Join(separator, properties.Select(p => p(element)));
		}
	}
