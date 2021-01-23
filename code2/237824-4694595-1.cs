    static void AssignValue<TSource, TResult>(Expression<Func<TSource, TResult>> expression, TSource source, TResult result)
    {
        var paramExp = expression.Parameters.Single();
        var assignExp = Expression.Assign(expression.Body, Expression.Constant(result));
        var lambdaExp = Expression.Lambda(assignExp, paramExp);
        lambdaExp.Compile().DynamicInvoke(source);
    }
