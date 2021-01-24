    static Func<Tasks, Tasks> CreateSelect(string[] columns)
    {
    	var parameterExpression = Expression.Parameter(typeof(Tasks), "p");
    	var newExpression = Expression.New(typeof(Tasks));
    
    	var bindings = columns.Select(o => o.Trim())
    		.Select(o =>
    		{
    			var pi = typeof(Tasks).GetProperty(o);
    			var memberExpression = Expression.Property(parameterExpression, pi);
    			return Expression.Bind(pi, memberExpression);
    		}
    	);
    	var memberInitExpression = Expression.MemberInit(newExpression, bindings);
    	var lambda = Expression.Lambda<Func<Tasks, Tasks>>(memberInitExpression, parameterExpression);
    	return lambda.Compile();
    }
