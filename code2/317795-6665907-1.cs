    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source,
    			Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            foreach (T element in source)
            {
                action(element);
            }
    
            return source;
        }
    }
