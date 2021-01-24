    public static int FindSubArray<T>(this IReadOnlyList<T> x, IReadOnlyList<T> y)
    {
    	int offset = 0;
    	for (int i = 0; i < x.Count; ++i)
    	{
    		if (y.SequenceEqual(x.Skip(i).Take(y.Count)))
    		{
    			offset = i;
    			break;
    		}
    	}
    	return offset;
    }
