	public static T GetByCodi<T>(IQueryable<T> table, string codi) where T : class
	{
		// x
		ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
		Expression currentExpression = parameter;
		Type currentType = typeof(T);
		PropertyInfo property = currentType.GetProperty("CODI_" + currentType.Name);
		
		// x.CODI_xxx
		currentExpression = Expression.Property(currentExpression, property);
		
		// x.CODI_xxx == codi
		currentExpression = Expression.Equal(currentExpression, Expression.Constant(codi));
		
		// x => x.CODI_xxx == codi
		LambdaExpression lambdaExpression = Expression.Lambda(currentExpression, parameter);
		
		return table.FirstOrDefault((Func<T, bool>)lambdaExpression.Compile());
	}
