    public static class FullOuterJoinExtension
    {
        private static IDictionary<TK, IEnumerable<TV>> ToDictionary<TK,TV>(this IEnumerable<IGrouping<TK, TV>> grouping)
        {
            return grouping.ToDictionary(g => g.Key, g => g.AsEnumerable());
        }
        private static IEnumerable<TV> OuterGet<TK, TV>(this IDictionary<TK, IEnumerable<TV>> dict, TK k, TV d=default(TV))
        {
            IEnumerable<TV> result;
            return dict.TryGetValue(k, out result) ? result : new [] { d };
        }
        public static IList<TR> FullOuterJoin<TA, TB, TK, TR>(this IEnumerable<TA> a, 
            IEnumerable<TB> b, 
            Func<TA, TK> selectKeyA, Func<TB, TK> selectKeyB, 
            Func<TA, TB, TK, TR> projection, 
            TA defaultA=default(TA), TB defaultB=default(TB))
        {
            var adict = a.GroupBy(selectKeyA).ToDictionary();
            var bdict = b.GroupBy(selectKeyB).ToDictionary();
            var keys = adict.Keys.Union(bdict.Keys);
            var join = from key in keys
                       from xa in adict.OuterGet(key, defaultA)
                       from xb in bdict.OuterGet(key, defaultB)
                       select projection(xa, xb, key);
            return join.ToList();
        }
    }
