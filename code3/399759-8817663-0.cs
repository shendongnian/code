	public static MethodInfo MethodOf( Expression<System.Action> expression )
	{
		MethodCallExpression body = (MethodCallExpression)expression.Body;
		return body.Method;
	}
