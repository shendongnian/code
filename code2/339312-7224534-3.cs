    internal static IEnumerable<T> InterleaveEnumerationsOfEqualLength<T>(
        this IEnumerable<T> first, 
        IEnumerable<T> second)
    {
    	using (IEnumerator<T>
    		enumerator1 = first.GetEnumerator(),
    		enumerator2 = second.GetEnumerator())
    	{
    		while (enumerator1.MoveNext() && enumerator2.MoveNext())
    		{
    			yield return enumerator1.Current;
    			yield return enumerator2.Current;
    		}
    	}
    }
