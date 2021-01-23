    /// <summary>
    /// Performs the specified action on each element of the IEnumerable.
    /// </summary>
    public static void ForEachAction<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
    	if (action == null || enumerable == null)
    	{
    		throw new ArgumentNullException();
    	}
    
    	foreach (var item in enumerable)
    	{
    		action.Invoke(item);
    	}
    }
