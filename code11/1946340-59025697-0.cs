    public static Expression<Action<T, K>> GetActionExpression<T, K>(string methodName, int val)
    {
        ParameterExpression ctx = Expression.Parameter(typeof(T), "ctx");
        ParameterExpression product = Expression.Parameter(typeof(K), "model");
        ParameterExpression actionMethodParam = Expression.Parameter(typeof(int), "val");
        var lambdaExpr = Expression.Lambda<Action<T, K>>(
            Expression.Call(
                      product,
                      typeof(K).GetMethod(methodName, new Type[] { typeof(int) }),
                      Expression.Constant(val)), new ParameterExpression[] {
                      ctx, product
                  }
            );
            return lambdaExpr;
    }
