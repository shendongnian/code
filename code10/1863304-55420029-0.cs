    public static Expression<Func<T, bool>> CreateExpression<T>(Ledger ledger)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        Expression body = null;
        foreach (var property in ledger.GetType().GetProperties())
        {
            var value = property.GetValue(ledger);
            if (value == null)
                continue;
            var equals = Expression.Equal(
                Expression.Property(parameter, property.Name),
                Expression.Constant(value));
            body = body == null ? equals : Expression.AndAlso(body, equals);
        }
        if (body == null) // no filters
            body = Expression.Constant(true);
        var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
        return lambda;
    }
    
