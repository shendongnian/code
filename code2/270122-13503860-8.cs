    internal static class MyExtensions
    {
        public static IDictionary<TK, IEnumerable<TV>> ToDictionary<TK,TV>(this IEnumerable<IGrouping<TK, TV>> grouping)
        {
            return grouping.ToDictionary(g => g.Key, g => g.AsEnumerable());
        }
        internal static IEnumerable<TV> OuterGet<TK, TV>(this IDictionary<TK, IEnumerable<TV>> dict, TK k)
        {
            IEnumerable<TV> result;
            if (!dict.TryGetValue(k, out result))
                yield break;
            
            foreach (var v in result) 
                yield return v;
        }
        internal static IList<TR> FullOuterGroupJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB,
            Func<IEnumerable<TA>, IEnumerable<TB>, TK, TR> projection)
        {
            var adict = a.GroupBy(selectKeyA).ToDictionary();
            var bdict = b.GroupBy(selectKeyB).ToDictionary();
            var keys = new HashSet<TK>(adict.Keys);
            keys.UnionWith(bdict.Keys);
            var join = from key in keys
                       let xa = adict.OuterGet(key)
                       let xb = bdict.OuterGet(key)
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
            var adict = a.GroupBy(selectKeyA).ToDictionary();
            var bdict = b.GroupBy(selectKeyB).ToDictionary();
            var keys = new HashSet<TK>(adict.Keys);
            keys.UnionWith(bdict.Keys);
            var join = from key in keys
                       from xa in adict.OuterGet(key).DefaultIfEmpty(defaultA)
                       from xb in bdict.OuterGet(key).DefaultIfEmpty(defaultB)
                       select projection(xa, xb, key);
            return join.ToList();
        }
    }
