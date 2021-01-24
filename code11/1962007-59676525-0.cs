    public static IQueryable<T> ContainsByField<T>(this IQueryable<T> q, string field, string value)
    {
    	var eParam = Expression.Parameter(typeof(T), "e");
    	var method = field.GetType().GetMethod("Contains");
    	var call = Expression.Call(Expression.Property(eParam, field), method, Expression.Constant(value.ToLower()));
    	var lambdaExpression = Expression.Lambda<Func<T, bool>>(
    		Expression.AndAlso(
    			Expression.NotEqual(Expression.Property(eParam, field), Expression.Constant(null)),
    			call
    		),
    		eParam
    	);
    
    	return q.Where(lambdaExpression);
    }
