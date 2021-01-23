    yourSequence.ForEach(x => Console.WriteLine(x));
    // ...
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            foreach (T item in source)
            {
                action(item);
            }
        }
    }
