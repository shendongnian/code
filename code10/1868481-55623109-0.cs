	public static int Count<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		ICollection<TSource> collection = source as ICollection<TSource>;
		if (collection != null)
		{
			return collection.Count;
		}
		ICollection collection2 = source as ICollection;
		if (collection2 != null)
		{
			return collection2.Count;
		}
		int num = 0;
		using (IEnumerator<TSource> enumerator = source.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				num = checked(num + 1);
			}
			return num;
		}
	}
