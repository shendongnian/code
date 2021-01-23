    IQueryable<E> query = ...;
    IOrderedQueryable<E> ordered = null;
    foreach (var key in entityKeys)
    {
        // Code from Doggett to construct the lambda expression for one step
        ParameterExpression param = Expression.Parameter(typeof(E), "a");
        var body = Expression.TypeAs(
            Expression.PropertyOrField(param, key),
            typeof(IComparable));
        var exp = Expression.Lambda<Func<E, IComparable>>(body, param);
        if (ordered == null)
            ordered = query.OrderBy(exp);
        else
            ordered = ordered.ThenBy(exp);
    }
    var finalQuery = (ordered ?? query).Skip(n).Take(m);
