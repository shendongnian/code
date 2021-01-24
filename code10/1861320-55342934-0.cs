    // build lambda expression (T t) => t.KeyField
    var type = typeof(T);
    var parameter = Expression.Parameter(type, "k");
    var lambda = Expression.Lambda(Expression.Property(parameter, keyField), parameter);
    // get source expression
    var baseExpression = queryable.Expression;
    
    // call to OrderBy
    var orderByCall = Expression.Call(
        typeof(Queryable),
        "OrderBy",
        new[] {type, keyField.PropertyType},
        baseExpression, lambda
    );
    // sorted result
    var sorted = queryable.Provider.CreateQuery<T>(orderByCall);
