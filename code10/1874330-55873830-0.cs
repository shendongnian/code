    // TRes combineFn(T prevValue, T curValue)
    public static IEnumerable<TRes> ScanByPairs<T, TRes>(this IEnumerable<T> src, Func<T, T, TRes> combineFn) {
        using (var srce = src.GetEnumerator())
            if (srce.MoveNext()) {
                var prev = srce.Current;
                while (srce.MoveNext())
                    yield return combineFn(prev, prev = srce.Current);
            }
    }
