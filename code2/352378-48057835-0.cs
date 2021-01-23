    public static IEnumerable<TItem> Range<TItem>(
    	TItem itemFrom, TItem itemTo, Func<TItem, TItem> itemSelector
    ) where TItem : IComparable
    {
        // Call to the below method
    	return Range(itemFrom, itemTo, itemSelector, o => o);
    }
    public static IEnumerable<TItem> Range<TItem, TResult>(
        TItem itemFrom, TItem itemTo, Func<TItem, TItem> itemSelector, Func<TItem, TResult> resultSelector
    ) where TItem : IComparable
    {
      	while (true)
       	{
       		yield return resultSelector(itemFrom);
       
       		if ((itemFrom = itemSelector(itemFrom)).CompareTo(itemTo) > 0)
       			break;
       	}
    }
