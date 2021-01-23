    static Predicate<TObject> Compiler<TObject, TProperty>(
        Expression<Func<TObject, IEnumerable<TProperty>>> selector,
        Expression<Predicate<TProperty>> predicate)
    {
        var query = FindMethod<TProperty>(typeof(Enumerable), "All");
        var predicateAsFunc = Expression.Lambda<Func<TProperty, bool>>(
            predicate.Body, 
            predicate.Parameters);
        var expression = Expression.Call(
            query,
            new Expression[] 
            { 
                Expression.Invoke(selector, selector.Parameters), 
                predicateAsFunc 
            });
        return Expression
            .Lambda<Predicate<TObject>>(expression, selector.Parameters)
            .Compile();
    }
