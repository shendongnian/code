    public static T SingleOrNew<T>(this IEnumerable<T> query, Func<T> createNew)
    {
    	using (var enumerator = query.GetEnumerator())
    	{
    		if (enumerator.MoveNext() && !enumerator.MoveNext())
    		{
    			return enumerator.Current;
    		}
    		else
    		{
    			return createNew();
    		}
    	}
    }
