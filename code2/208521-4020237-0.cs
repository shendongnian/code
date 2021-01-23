    public static class Extension
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach(var currentItem in enumerable)
            {
                action(currentItem);
            }
        }
    }
