    public static class IQueryableExt {
        static IQueryable<T> _inner<T>(this ExpandableQuery<T> eq) {
            var ExpandableQuery__inner_FieldInfo = typeof(ExpandableQuery<T>).GetField("_inner", BindingFlags.NonPublic | BindingFlags.Instance);
            return (IQueryable<T>)ExpandableQuery__inner_FieldInfo.GetValue(eq);
        }
    
        public static string ToTraceString<T>(this IQueryable<T> q) {
            switch (q) {
                case ObjectQuery<T> oq: return oq.ToTraceString();
                case ExpandableQuery<T> eq: return eq._inner().ToTraceString();
                default:
                    return q.ToString();
            }
        }
    }
