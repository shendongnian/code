    static class Extensions
    {
        public static void Iterate<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
