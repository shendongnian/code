    public static class IEnumerableExt {
        public static TRes HeadAndTail<T, TRes>(this IEnumerable<T> src, Func<T,IEnumerable<T>,TRes> headAndTailFn) {
            var e = src.GetEnumerator();
            if (e.MoveNext()) {
                IEnumerable<T> EnumerateRest() {
                    while (e.MoveNext())
                        yield return e.Current;
                }
    
                var f = e.Current;
                return headAndTailFn(f, EnumerateRest());
            }
            else
                throw new ArgumentException("src must have at least one element");
        }
    
        public static TAcc Aggregate<T, TAcc>(this IEnumerable<T> src, Func<T, TAcc> seedFn, Func<TAcc, T, TAcc> aggFn) =>
                src.HeadAndTail((f, r) => r.Aggregate(seedFn(f), aggFn));
    }
