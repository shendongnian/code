    namespace joinext
    {    
    public static class JoinExtensions
        {
            public static IEnumerable<TResult> FullOuterJoin<TOuter, TInner, TKey, TResult>(
                this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner,
                Func<TOuter, TKey> outerKeySelector,
                Func<TInner, TKey> innerKeySelector,
                Func<TOuter, TInner, TResult> resultSelector)
                where TInner : class
                where TOuter : class
            {
                var innerLookup = inner.ToLookup(innerKeySelector);
                var outerLookup = outer.ToLookup(outerKeySelector);
    
                var innerJoinItems = inner
                    .Where(innerItem => !outerLookup.Contains(innerKeySelector(innerItem)))
                    .Select(innerItem => resultSelector(null, innerItem));
    
                return outer
                    .SelectMany(outerItem =>
                    {
                        var innerItems = innerLookup[outerKeySelector(outerItem)];
    
                        return innerItems.Any() ? innerItems : new TInner[] { null };
                    }, resultSelector)
                    .Concat(innerJoinItems);
            }
    
    
            public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
                this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner,
                Func<TOuter, TKey> outerKeySelector,
                Func<TInner, TKey> innerKeySelector,
                Func<TOuter, TInner, TResult> resultSelector)
            {
                return outer.GroupJoin(
                    inner,
                    outerKeySelector,
                    innerKeySelector,
                    (o, i) =>
                        new { o = o, i = i.DefaultIfEmpty() })
                        .SelectMany(m => m.i.Select(inn =>
                            resultSelector(m.o, inn)
                            ));
    
            }
    
    
    
            public static IEnumerable<TResult> RightJoin<TOuter, TInner, TKey, TResult>(
                this IEnumerable<TOuter> outer,
                IEnumerable<TInner> inner,
                Func<TOuter, TKey> outerKeySelector,
                Func<TInner, TKey> innerKeySelector,
                Func<TOuter, TInner, TResult> resultSelector)
            {
                return inner.GroupJoin(
                    outer,
                    innerKeySelector,
                    outerKeySelector,
                    (i, o) =>
                        new { i = i, o = o.DefaultIfEmpty() })
                        .SelectMany(m => m.o.Select(outt =>
                            resultSelector(outt, m.i)
                            ));
    
            }
    
        }
    }
