    internal static class MyExtensions
    {
        internal static IList<TR> FullOuterGroupJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB,
            Func<IEnumerable<TA>, IEnumerable<TB>, TK, TR> projection)
        {
            var alookup = a.ToLookup(selectKeyA);
            var blookup = b.ToLookup(selectKeyB);
            var keys = new HashSet<TK>(alookup.Select(p => p.Key));
            keys.UnionWith(blookup.Select(p => p.Key));
            var join = from key in keys
                       let xa = alookup[key]
                       let xb = blookup[key]
                       select projection(xa, xb, key);
            return join.ToList();
        }
        internal static IList<TR> FullOuterJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB,
            Func<TA, TB, TK, TR> projection,
            TA defaultA = default(TA), TB defaultB = default(TB))
        {
            var alookup = a.ToLookup(selectKeyA);
            var blookup = b.ToLookup(selectKeyB);
            var keys = new HashSet<TK>(alookup.Select(p => p.Key));
            keys.UnionWith(blookup.Select(p => p.Key));
            var join = from key in keys
                       from xa in alookup[key].DefaultIfEmpty(defaultA)
                       from xb in blookup[key].DefaultIfEmpty(defaultB)
                       select projection(xa, xb, key);
            return join.ToList();
        }
    }
