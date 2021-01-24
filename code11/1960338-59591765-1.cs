    public static class Extensions
    {
    	public static T GetDefaultValue<S,T>(this S source,Expression<Func<S,T>> expression)
    	{
    		var body = expression.Body as MemberExpression;
    		if(body.Member.GetCustomAttributes<DefaultValueAttribute>().Any())
    		{
    		    return (T)body.Member.GetCustomAttribute<DefaultValueAttribute>().Value;
    		}
    		return default;
    	}
    }
