    public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string sortColumn, string direction)
    {
        if (string.IsNullOrEmpty(sortColumn))
            return query;
        string methodName = string.Format("OrderBy{0}",
            direction.ToLower() == "asc" ? "" : "descending");
        ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
        MemberExpression memberAccess = null;
        foreach (var property in sortColumn.Split('.'))
            memberAccess = MemberExpression.Property(memberAccess ?? (parameter as Expression), property);
        LambdaExpression orderByLambda = Expression.Lambda(memberAccess, parameter);
        MethodCallExpression result = Expression.Call(
                  typeof(Queryable),
                  methodName,
                  new[] { query.ElementType, memberAccess.Type },
                  query.Expression,
                  Expression.Quote(orderByLambda));
        return query.Provider.CreateQuery<T>(result);
    }
    
    public static IQueryable<T> Where<T>(this IQueryable<T> query, string column, object value, string operation)
    {
        if (string.IsNullOrEmpty(column))
            return query;
        ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");
        MemberExpression memberAccess = null;
        foreach (var property in column.Split('.'))
            memberAccess = MemberExpression.Property
               (memberAccess ?? (parameter as Expression), property);
        //change param value type
        //necessary to getting bool from string
        ConstantExpression filter = Expression.Constant
            (
                Convert.ChangeType(value, memberAccess.Type)
            );
        //switch operation
        LambdaExpression lambda = null;
        switch (operation)
        {
            case "eq": // equal
                {
                    lambda = Expression.Lambda(Expression.Equal(memberAccess, filter), parameter);
                    break;
                }
            case "ne": // not equal
                {
                    lambda = Expression.Lambda(Expression.NotEqual(memberAccess, filter), parameter);
                    break;
                }
            case "cn": // contains
                {
                    Expression condition = Expression.Call(memberAccess,
                                                           typeof (string).GetMethod("Contains"),
                                                           Expression.Constant(value.ToString()));
                    lambda = Expression.Lambda(condition, parameter);
                    break;
                }
        }
        var result = Expression.Call(
               typeof(Queryable), "Where",
               new[] { query.ElementType },
               query.Expression,
               lambda);
        return query.Provider.CreateQuery<T>(result);
    }
