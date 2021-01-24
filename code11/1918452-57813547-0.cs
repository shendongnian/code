    public static class IEnumerableExt {
        // Explicit seed value
        // TRes combineFn(TRes PrevResult, T CurValue)
        public static IEnumerable<TRes> Scan<T, TRes>(this IEnumerable<T> src, TRes seed, Func<TRes, T, TRes> combineFn) {
            foreach (var s in src) {
                seed = combineFn(seed, s);
                yield return seed;
            }
        }    
    }
