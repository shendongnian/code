    public static class DeletableExtensions
    {
        public static Deletable<T>[] AsDeleteable<T>(this IEnumerable<T> source)
        {
            return source.Select(item => new Deletable<T>(item)).ToArray();
        }
        public static IEnumerable<T> FilterDeleted<T>(this IEnumerable<Deletable<T>> source)
        {
            return source.Where(item => !item.Delete).Select(item => item.Value);
        }
    }
