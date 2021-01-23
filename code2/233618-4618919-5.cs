    public static class Extensions
    {
        public static EntitySet<T> ToEntitySet<T>(this IEnumerable<T> source)
            where T : class
        {
            var entitySet = new EntitySet<T>();
            entitySet.AddRange(source);
            return entitySet;
        }
    }
