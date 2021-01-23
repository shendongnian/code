    IEnumerable<Tuple<Expression<Func<T, object>>, Expression<Func<object>>>> directJoins;
    IEnumerable<Tuple<Expression<Func<object>>, Expression<Func<object>>>> indirectJoins;
    // ....
    foreach (var join in directJoins)
        query = queryable.Left.JoinAlias(dependency.Item1, dependency.Item2);
    foreach (var join in indirectJoins)
        query = queryable.Left.JoinAlias(dependency.Item1, dependency.Item2);
