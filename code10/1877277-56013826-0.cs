    public static class IEnumerableExt {
        // TRes seedFn(T FirstValue)
        // TRes combineFn(TRes PrevResult, T CurValue)
        public static IEnumerable<TRes> Scan<T, TRes>(this IEnumerable<T> src, Func<T, TRes> seedFn, Func<TRes, T, TRes> combineFn) {
            using (var srce = src.GetEnumerator()) {
                if (srce.MoveNext()) {
                    var prev = seedFn(srce.Current);
    
                    while (srce.MoveNext()) {
                        yield return prev;
                        prev = combineFn(prev, srce.Current);
                    }
                    yield return prev;
                }
            }
        }
    }
