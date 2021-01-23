    static class ExtentionsMethods
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> seq, int size)
        {
            while (seq.Any())
            {
                yield return seq.Take(size);
                seq = seq.Skip(size);
            }
        }
    }
