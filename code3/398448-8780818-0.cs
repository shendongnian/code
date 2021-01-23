    public static class EnumerableExtensions
    {
        /// <summary>Does two checks, if not null and if it has items.</summary>
        /// <returns>True if it is not null and has at least 1 item.</returns>
        public static bool ValidWithItems<T>( this IEnumerable<T> target )
        {
            return ((target != null) && (target.Any()));
        }
    }
