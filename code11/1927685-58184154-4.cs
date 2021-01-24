    public static IEnumerable<(T, T)> Pairwise<T>(IEnumerable<T> collection)
    {
    	using (var enumerator = collection.GetEnumerator())
    	{
    		enumerator.MoveNext();
    		var previous = enumerator.Current;
    		while (enumerator.MoveNext())
    		{
    			yield return (previous, enumerator.Current);
    			previous = enumerator.Current;
    		}
    	}
    }
