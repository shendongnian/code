    internal static IEnumerable<T> Interleave<T>(
        this IEnumerable<T> first, 
        IEnumerable<T> second)
    {
    	using (IEnumerator<T>
    		enumerator1 = first.GetEnumerator(),
    		enumerator2 = second.GetEnumerator())
    	{
    		while (enumerator1.MoveNext())
    		{
    			yield return enumerator1.Current;
    			if (enumerator2.MoveNext())
    				yield return enumerator2.Current;
    		}
    	}
    }
