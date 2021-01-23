    internal static class myExpressionService
    {
        public static string Get(Expression<Action> expression)
        {
            MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
            var method = methodCallExpression.Method;
            var argument = (ConstantExpression) methodCallExpression.Arguments.First();
            return string.Format("{0}.{1}({2})", method.DeclaringType.FullName, method.Name, argument.Value);
        }
    }
