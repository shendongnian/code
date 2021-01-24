	ParameterExpression paramExpr = Expression.Parameter(typeof(string), "Name");
	
	LambdaExpression lambdaExpr = Expression.Lambda(
	    Expression.Assign(
	        paramExpr,
	        Expression.Constant("Joe Foo")
	    ),
	    new List<ParameterExpression>() { paramExpr }
	);
	
	var user = new User();
	Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(user.Name));
