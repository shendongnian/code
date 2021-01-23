     public static object[] GetParams<T>(this T obj, Expression<Action<T>> action)
        {
            return ((MethodCallExpression) action.Body).Arguments.Cast<ConstantExpression>().Select(e => e.Value).ToArray();
        }
    
