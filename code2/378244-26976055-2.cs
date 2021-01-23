    private static bool IsNET45 = Type.GetType("System.Reflection.ReflectionContext", false) != null;
    public static string MethodName(LambdaExpression expression)
    {
        var unaryExpression = (UnaryExpression)expression.Body;
        var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
        if (IsNET45)
        {
            var methodCallObject = (ConstantExpression)methodCallExpression.Object;
            var methodInfo = (MethodInfo)methodCallObject.Value;
            return methodInfo.Name;
        }
        else
        {
            var methodInfoExpression = (ConstantExpression)methodCallExpression.Arguments.Last();
            var methodInfo = (MemberInfo)methodInfoExpression.Value;
            return methodInfo.Name;
        }
    }
