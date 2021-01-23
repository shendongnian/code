    public static class Sequence
    {
        public static IEnumerable<T> Generate<T>(T seed, Func<T, T> next)
        {
            while (true)
            {
                seed = next(seed);
                yield return seed;
            }
        }
    }
