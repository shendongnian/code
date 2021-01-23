    public static class ExtMethods
    {
        public static IEnumerable<T> NotOfType<T, U>(this IEnumerable<T> source)
        {
            return source.Where(t => !(t is U));
        }
          // helper method for type inference by example
        public static IEnumerable<T> NotOfSameType<T, U>(
          this IEnumerable<T> source,
          U example)
        {
            return source.NotOfType<T, U>();
        }
    }
