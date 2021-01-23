    public static class CollectionUtils
    {
        public static Collection<T> ToCollection<T>(this IEnumerable<T> data)
        {
            return new Collection<T>(data.ToList());
        }
    }
