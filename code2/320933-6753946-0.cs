    public static class EnumerableExtensions {
        public static bool AnyAreNotNull<T>(this IEnumerable<T> source) {
            Contract.Requires(source != null);
            return source.Any(x => x != null);
        }
    }
