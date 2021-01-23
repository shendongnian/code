    static class EnumerableX
    {
        public static IEnumerable<IList<T>> BufferWithCount<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            var buffer = new List<T>();
            
            foreach (var t in source)
            {
                buffer.Add(t);
                if (buffer.Count == count)
                {
                    yield return buffer;
                    buffer = new List<T>();
                }
            }
            if (buffer.Count > 0)
            {
                yield return buffer;
            }
        }
    }
