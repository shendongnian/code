    int sum = A().Scan((s, x) => s + x).First(s => s > N);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Scan<T>(
            this IEnumerable<T> source, Func<T, T, T> func)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");
            using (var e = source.GetEnumerator())
            {
                if (e.MoveNext())
                {
                    T accumulator = e.Current;
                    yield return accumulator;
                    while (e.MoveNext())
                    {
                        accumulator = func(accumulator, e.Current);
                        yield return accumulator;
                    }
                }
            }
        }
    }
