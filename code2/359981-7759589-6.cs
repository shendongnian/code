    static Predicate<TObject> Compiler<TObject, TProperty>(
        Expression<Func<TObject, IEnumerable<TProperty>>> selector,
        Expression<Func<TProperty, bool>> predicate)
    {
        var query = FindMethod<TProperty>(typeof(Enumerable), "All");
        var queryParameter = Expression.Parameter(typeof(TObject));
        var expression = Expression.Call(query,
            new Expression[] 
            { 
                Expression.Invoke(selector, queryParameter), predicate 
            });
        return Expression.Lambda<Predicate<TObject>>(expression, queryParameter)
            .Compile();
    }
