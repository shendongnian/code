    static Predicate<TObject> Compiler<TObject, TProperty>(
        Expression<Func<TObject, IEnumerable<TProperty>>> selector,
        Expression<Func<TProperty, bool>> predicate)
    {
        var query = FindMethod<TProperty>(typeof(Enumerable), "All");
        var expression = Expression.Call(
            query,
            new Expression[] 
            { 
                Expression.Invoke(selector, selector.Parameters), 
                predicate 
            });
        return Expression
            .Lambda<Predicate<TObject>>(expression, selector.Parameters)
            .Compile();
    }
