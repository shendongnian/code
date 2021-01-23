    public static bool IsOrdered<T>(this IQueryable<T> queryable)
    {
    	if (queryable == null)
    	{
    		throw new ArgumentNullException("queryable");
    	}
    
    	return queryable.Expression.Type == typeof(IOrderedQueryable<T>);
    }
