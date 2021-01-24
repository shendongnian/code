    public static class DeletableExtensions
    {
        public static IEnumerable<Deletable<T>> AsDeleteable<T>(this IEnumerable<T> source)
        {
            return source.Select(item => new Deletable<T>(item));
        }
        public static IEnumerable<T> FilterDeleted<T>(this IEnumerable<Deletable<T>> source)
        {
            return source.Where(item => !item.Delete).Select(item => item.Value);
        }
    }
