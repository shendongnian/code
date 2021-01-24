    public static IEnumerable<Tuple<T, T>> Pairwise<T>(IEnumerable<T> collection)
    {
    	using (var enumerator = collection.GetEnumerator())
    	{
    		enumerator.MoveNext();
    		var previous = enumerator.Current;
    		while (enumerator.MoveNext())
    		{
    			yield return new Tuple<T, T>(previous, enumerator.Current);
    			previous = enumerator.Current;
    		}
    	}
    }
