    public static class Sequence
    {
        public static IEnumerable<T> Create<T>(T seed, Func<T, bool> predicate, Func<T, T> next)
        {
            for (T t = seed; predicate(t); t = next(t))
                yield return t;
        }
    }
