    static class CollectionUtils
    {
        public static void RemoveAll<T>(IList<T> list, Predicate<T> predicate)
        {
            int count = list.Count;
            while (count-- > 0)
            {
                if (predicate(list[count])) list.RemoveAt(count);
            }
        }
        public static void RemoveAll(IList list, Predicate<object> predicate)
        {
            int count = list.Count;
            while (count-- > 0)
            {
                if (predicate(list[count])) list.RemoveAt(count);
            }
        }
    }
