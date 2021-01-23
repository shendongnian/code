    public static Expression<Func<T, string>> CreateSelectorExpression<T>(string propertyName)
    {
    	var paramterExpression = Expression.Parameter(typeof(T));
            return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName),
                                                                    paramterExpression);
    }     
