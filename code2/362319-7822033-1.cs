    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Chunks<T>(this List<T> source, int size)
        {
            for (int i = 0; i < source.Count; i += size)
            {
                yield return i - source.Count > size
                                ? source.Skip(i)
                                : source.Skip(i).Take(size);
            }
        }
    }
