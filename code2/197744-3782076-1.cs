    public static class Extensions
    {
        public static bool ContainsNonDefaultValue<T>(this IEnumerable<T> source)
             where T : IEquatable<T>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            T zero = default(T);
            return items.Any(t => !t.Equals(zero));
        }
    }
