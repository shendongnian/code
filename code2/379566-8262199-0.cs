    public static Expression<Func<TResult, bool>> GetPredicate<TKey>
        (Expression<Func<TResult, TKey>> selector, TResult input, object value)
    {
        // Note: Move "early out" here so that bulk of method is less deeply nested.
        // Really? Why make this generic in TKey then?
        if (typeof(TKey) != typeof(string))
        {
            throw new Exception("Type not supported");
        }
        var parameter = Expression.Parameter("input");
        var invocation = Expression.Invoke(selector, input);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(invocation, constant);
        return Expression.Lambda<Func<TResult, bool>>(equality, parameter);
    }
