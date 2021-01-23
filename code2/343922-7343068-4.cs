    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Pad<T>(this IEnumerable<T> source,
            int desiredCount, T padWith = default(T))
        {
            // Note: Not using source.Count() to avoid double-enumeration
            int counter = 0;
            var enumerator = source.GetEnumerator();
            while(counter < desiredCount)
            {
                yield return enumerator.MoveNext()
                    ? enumerator.Current
                    : padWith;
                ++counter;
            }
        }
    }
