    public static IEnumerable<TResult> ZipAll<T, TResult>(
    	IEnumerable<IEnumerable<T>> lists,
    	Func<IEnumerable<T>, TResult> func)
    {
    	var enumerators = lists.Select(l => l.GetEnumerator()).ToArray();
    	while(enumerators.All(e => e.MoveNext()))
    	{	
    		yield return func(enumerators.Select(e => e.Current));
    	}
    	
    	foreach (var enumerator in enumerators)
    	{
    		enumerator.Dispose();
    	}
    }
