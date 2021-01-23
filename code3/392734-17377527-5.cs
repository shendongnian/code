    public static class Sequence
    {
        public static IEnumerable<T> Generate<T>(T seed, Func<T, T> next)
        {
            while (true)
            {
                yield return seed;
                seed = next(seed);
            }
        }
    }
