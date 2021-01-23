        public static IList<T> RemoveAllKeepRemoved<T>(this IList<T> source, Predicate<T> predicate)
        {
            IList<T> removed = new List<T>();
            for (int i = source.Count - 1; i >= 0; i--)
            {
                T item = source[i];
                if (predicate(item))
                {
                    removed.Add(item);
                    source.RemoveAt(i);
                }
            }
            return removed;
        }
