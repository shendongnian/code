    private static Expression<Func<TSource, bool>> CreatePropertyFilter<TSource>
        (Expression<Func<TSource, string>> selector, 
         string value, 
         TextMatchMode matchMode)
    {
        // Argument-checking here.    
        var body = selector.Body as MemberExpression;
    
        if (body == null)
            throw new ArgumentException("Not a MemberExpression.");    
    
        // string.StartsWith / EndsWith etc. depending on the matchMode.
        var method = typeof(string)
                     .GetMethod(GetMethodName(matchMode), new[] { typeof(string) });
    
        // input.Member.method(value)
        var compEx = Expression.Call(body, method, Expression.Constant(value));
        // We can reuse the parameter of the source.
        return Expression.Lambda<Func<TSource, bool>>(compEx, selector.Parameters);
    }
