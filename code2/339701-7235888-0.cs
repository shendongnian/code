    static class LinqHelper
    {
    	public static IEnumerable<T[]> SplitIntoGroups<T>(this IEnumerable<T> items, int N)
    	{
    		if (items == null || N < 1)
    			yield break;
    			
    		T[] group = new T[N];
    		int size = 0;
    		var iter = items.GetEnumerator();
    
    		while (iter.MoveNext())
    		{
    			group[size++] = iter.Current;
    			if (size == N)
    			{
    				yield return group;
    				size = 0;
    				group = new T[N];
    			}
    		}
    		if (size > 0)
    			yield return group.Take(size).ToArray();
    	}
    }
