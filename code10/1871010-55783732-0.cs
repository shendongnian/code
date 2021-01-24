    public static Expression<Func<Tin, Tout>> Transform<Tin, Tout>(this Expression<Func<Tin, object>> source)
    {
    	return Expression.Lambda<Func<Tin, Tout>>(
    		Transform(source.Body, typeof(Tout)),
    		source.Parameters);
    }
    
    static Expression Transform(Expression source, Type type)
    {
    	if (source.Type != type && source is NewExpression newExpr && newExpr.Members.Count > 0)
    	{
    		return Expression.MemberInit(Expression.New(type), newExpr.Members
    			.Select(m => type.GetProperty(m.Name))
    			.Zip(newExpr.Arguments, (m, e) => Expression.Bind(m, Transform(e, m.PropertyType))));
    	}
    	return source;
    }
