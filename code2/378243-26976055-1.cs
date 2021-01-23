    public static string MethodName(LambdaExpression expression)
    {
        var unaryExpression = (UnaryExpression)expression.Body;
        var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
        var methodCallObject = (ConstantExpression)methodCallExpression.Object;
        var methodInfo = (MethodInfo)methodCallObject.Value;
         
        return methodInfo.Name;
    }
