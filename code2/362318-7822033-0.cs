    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this T[] source, int size)
        {
            for (int i = 0; i < source.Length; i += size)
            {
                yield return i - source.Length > size
                                ? source.Skip(i)
                                : source.Skip(i).Take(size);
            }
        }
    }
