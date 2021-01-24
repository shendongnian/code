    public static class ExpressionTreesExtesion
    {
    	public static Expression<Func<T,string>> OrderByExpression<T>(this IEnumerable<T> enumerable, string propertyName)
    	{
    		var propInfo = typeof(T).GetProperty(propertyName);
    
    		var collectionType = typeof(T);
    
    		var parameterExpression = Expression.Parameter(collectionType, "x");
    		var propertyAccess = Expression.MakeMemberAccess(parameterExpression, propInfo);
    		var orderExpression = Expression.Lambda<Func<T,string>>(propertyAccess, parameterExpression);
    		return orderExpression;
    	}
    }
