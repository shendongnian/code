    var query = foreignObj.GetPeople()
                          .AsNonNullEnumerable()
                          .Where(p => p.Name != "John")
                          .OrderBy(p => p.Name)
                          .Take(4);
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AsNonNullEnumerable<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
