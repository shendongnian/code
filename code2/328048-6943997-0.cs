    public static class EnumerableExtensions
    {
        public static IEnumerable<object> MakeGeneric(this IEnumerable nonGenericCollection)
        {
            return nonGeneric.Cast<object>();
        }
    }
