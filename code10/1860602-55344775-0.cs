    public static class ODataQueryOptionsExtensions
    {
    	public static Expression<Func<T, bool>> GetFilter<T>(this ODataQueryOptions<T> options)
    	{
    		// The same trick as in the linked post
    		IQueryable query = Enumerable.Empty<T>().AsQueryable();
    		query = options.Filter.ApplyTo(query, new ODataQuerySettings());
    		// Extract the predicate from `Queryable.Where` call
    		var call = query.Expression as MethodCallExpression;
    		if (call != null && call.Method.Name == nameof(Queryable.Where) && call.Method.DeclaringType == typeof(Queryable))
    		{
    			var predicate = ((UnaryExpression)call.Arguments[1]).Operand;
    			return (Expression<Func<T, bool>>)predicate;
    		}
    		return null;
    	}
    }
