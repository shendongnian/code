    public IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
        IQueryable<TOuter> outer,
        IQueryable<TInner> inner,
        Expression<Func<TOuter, TKey>> outerKeySelector,
        Expression<Func<TInner, TKey>> innerKeySelector,
        Expression<Func<TOuter, TInner, TResult>> resultSelector) {
        var leftJoin = outer.GroupJoin(
            inner,
            outerKeySelector,
            innerKeySelector,
            (o, i) => new {
                Outer = o,
                Inners = i
            }).SelectMany(
                oi => oi.Inners.DefaultIfEmpty(),
                (oi, i) => new {
                    oi.Outer,
                    Inner = i
                }
            );
        // Break the anonymous type of the left join into the two parameters needed for the resultSelector
        var anonymousType = leftJoin.GetType().GetGenericArguments()[0];
        var parameter = Expression.Parameter(anonymousType, "oi");
        // oi.Outer
        var outerProperty = Expression.Property(parameter, "Outer");
        // oi.Inner
        var innerProperty = Expression.Property(parameter, "Inner");
        // resultSelector = (o,i) => expr(o,i)
        // o
        var resultOuterParm = resultSelector.Parameters[0];
        // i
        var resultInnerParm = resultSelector.Parameters[1];
        // expr(o,i) --> expr(oi.Outer, oi.Inner)
        var newBody = resultSelector.Body.Replace(resultOuterParm, outerProperty).Replace(resultInnerParm, innerProperty);
        // oi => expr(oi.Outer, oi.Inner)
        Expression<Func<TAnonymous, TResult>> typeSafeLambda<TAnonymous>(IQueryable<TAnonymous> _) =>
            Expression.Lambda<Func<TAnonymous, TResult>>(newBody, parameter);
        var wrapper = typeSafeLambda(leftJoin);
        return leftJoin.Select(wrapper);
    }
