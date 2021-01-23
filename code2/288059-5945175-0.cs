	// I actually have a Pair<A,B> struct that I prefer to use, but 
	// KeyValuePair or Tuple works almost as well.
	public static IEnumerable<Tuple<A, B>> ZipTuples<A, B>(this IEnumerable<A> a, IEnumerable<B> b)
	{
		IEnumerator<A> ea = a.GetEnumerator();
		IEnumerator<B> eb = b.GetEnumerator();
		while (ea.MoveNext() && eb.MoveNext())
			yield return new Tuple<A, B>(ea.Current, eb.Current);
	}
	public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
	{
		foreach (T item in list)
			action(item);
	}
