    public static IQueryable<T> Sort<T>(IQueryable<T> source, string sortBy)
    {
        //create the expression tree that represents the generic parameter to the predicate
        var param = Expression.Parameter(typeof(T), "p");
        //create an expression tree that represents the expression p=>p.SortField.HasValue 
        var prop = Expression.Property(param, sortBy);
        var target = Expression.Constant(null, prop.Type);
        // NotEqual, to sort nulls before not-nulls
        var bin = Expression.NotEqual(prop, Expression.Convert(target, prop.Type));
        var exp = Expression.Lambda(bin, param);
        // OrderBy with the null comparison expression
        string method = nameof(Queryable.OrderBy);
        Type[] types = new Type[] { source.ElementType, exp.Body.Type };
        var orderByCallExpression = Expression.Call(typeof(Queryable), method, types, source.Expression, exp);
        // ThenBy with the property expression
        exp = Expression.Lambda(prop, param);
        types = new Type[] { source.ElementType, exp.Body.Type };
        method = nameof(Queryable.ThenBy);
        var ThenByCallExpression = Expression.Call(typeof(Queryable), method, types, orderByCallExpression, exp);
        return source.Provider.CreateQuery<T>(ThenByCallExpression);
    }
