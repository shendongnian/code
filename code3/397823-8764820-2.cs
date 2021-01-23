	protected static object EvaluateExpression(Expression expression, ParameterExpression parameterX)
	{
		var lambda = Expression.Lambda(expression, parameterX);
		var compiled = lambda.Compile();
		return compiled.DynamicInvoke(5); 
                // 5 here is the actual parameter value. change it to whatever you wish
	}
