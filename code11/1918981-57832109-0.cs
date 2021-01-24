	public static class ExpressionRetriever
	{
		private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string), typeof(StringComparison)});
		...
		
		public static Expression GetExpression<T>(ParameterExpression param, ExpressionFilter filter)
		{
			...
			ConstantExpression comparisonType = Expression.Constant(StringComparison.OrdinalIgnoreCase);
			switch (filter.Comparison)
			{
				...
				case Comparison.Contains:
					return Expression.Call(member, containsMethod, constant), comparisonType);
			}
		}
	}
