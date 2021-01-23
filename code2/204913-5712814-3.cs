    private static Expression<Func<T, bool>> GetFuncTbool<T>(IQueryable source, Func<dynamic, dynamic> expressionBuilder)
    {
        ParameterExpression parameterExpression = Expression.Parameter(GetElementType(source), expressionBuilder.Method.GetParameters()[0].Name);
        DynamicExpressionBuilder dynamicExpression = expressionBuilder(new DynamicExpressionBuilder(parameterExpression));
        Expression body = dynamicExpression.Expression;
        return Expression.Lambda<Func<T, bool>>(body, parameterExpression);
    }
