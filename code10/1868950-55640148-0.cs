    public static Expression<Func<T, bool>> CreatePredicate<T>(List<string> propsToSearch,
       string valueToSearch)
    {
        var parameter = Expression.Parameter(typeof(T), "record");
        // filtering is not required
        if (!propsToSearch.Any() || string.IsNullOrEmpty(valueToSearch))
            return Expression.Lambda<Func<T, bool>>(Expression.Constant(true), parameter);
        var props = typeof(T).GetProperties()
            .Select(p => p.Name)
            .Intersect(propsToSearch.Distinct());
        var containsMethod = typeof(string).GetMethod("Contains");
        var body = props
            .Select(p => Expression.PropertyOrField(parameter, p))
            .Aggregate((Expression) Expression.Constant(false),
                (c, n) => Expression.OrElse(c,
                    Expression.Call(n, containsMethod, Expression.Constant(valueToSearch)))
            );
        var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
        return lambda;
    }
