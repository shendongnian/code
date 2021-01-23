    public static IQueryable<T> Where<T>(this IQueryable<T> query, string column, object value, WhereOperation operation)
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
        Expression condition = null;
        LambdaExpression lambda = null;
        switch (operation)
        {
            //equal ==
            case WhereOperation.Equal:
                condition = Expression.Equal(memberAccess, filter);
                lambda = Expression.Lambda(condition, parameter);
                break;
            //not equal !=
            case WhereOperation.NotEqual:
                condition = Expression.NotEqual(memberAccess, filter);
                lambda = Expression.Lambda(condition, parameter);
                break;
            //string.Contains()
            case WhereOperation.Contains:
                condition = Expression.Call(memberAccess,
                    typeof(string).GetMethod("Contains"),
                    Expression.Constant(value));
                lambda = Expression.Lambda(condition, parameter);
                break;
        }
    
        
        MethodCallExpression result = Expression.Call(
               typeof(Queryable), "Where",
               new[] { query.ElementType },
               query.Expression,
               lambda);
    
        return query.Provider.CreateQuery<T>(result);
    }
