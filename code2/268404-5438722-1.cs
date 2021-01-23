    public static string GetMethodName<T>(Expression<Func<T, Object>> selector) where T : class
    {
        var expression = (MethodCallExpression)(selector.Body is UnaryExpression ? ((UnaryExpression)selector.Body).Operand : selector.Body);
        return expression.Method.Name;
    }
    public static string GetMethodName<T>(Expression<Action<T>> selector) where T : class
    {
        var expression = (MethodCallExpression)(selector.Body is UnaryExpression ? ((UnaryExpression)selector.Body).Operand : selector.Body);
        return expression.Method.Name;
    }
