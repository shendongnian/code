    public static int SumWhile(this IEnumerable<int> collection, Func<int, bool> condition)
    {
    	int sum = 0;
    	foreach (int i in collection)
    	{
    		sum += i;
    		if (!condition(sum))
    			return sum;
    	}
        return 0;
    }
