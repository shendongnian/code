    private static object GetValue(Expression expression)
    {
        var constantExpression = expression as ConstantExpression;
        if (constantExpression != null)
        {
            return constantExpression.Value;
        }
        var objectMember = Expression.Convert(expression, typeof(object));
        var getterLambda = Expression.Lambda<Func<object>>(objectMember);
        var getter = getterLambda.Compile();
        return getter();
    }
    private static object[] GetParameterValues(LambdaExpression expression)
    {
        var methodCallExpression = expression.Body as MethodCallExpression;
        if (methodCallExpression != null)
        {
            return methodCallExpression.Arguments.Select(GetValue).ToArray();
        }
        return null;
    }
