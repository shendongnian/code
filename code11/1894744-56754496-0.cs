    public static async Task<P> ExecuteAsync<T, P>(Expression<Func<IYoutubeController, P>> func)
    {    
        MethodCallExpression callExpression = expression.Body as MethodCallExpression;
        string methodName = callExpression.Method.Name;
        object argument = ((ConstantExpression)callExpression.Arguments).Value;
        // do something
    }
