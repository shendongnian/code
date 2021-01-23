    public static OpenActionDelegate GetOpenActionDelegate(Type type, string methodName) {
        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
        ParameterExpression instance = Expression.Parameter(typeof(object));
        ParameterExpression someParam = Expression.Parameter(typeof(float));
        Expression<OpenActionDelegate> expression = Expression.Lambda<OpenActionDelegate>(
            Expression.Call(
                Expression.Convert(
                    instance,
                    type
                ),
                method,
                someParam
            ),
            instance,
            someParam
        );
        return expression.Compile();
    }
