    public static class Utilities
    {
        // Will return true if it is not null and contains elements.
        public static bool NotNullAny<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }
        // Will return true if it is not null and contains elements that satisfy the condition.
        public static bool NotNullAny<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable != null && enumerable.Any(predicate);
        }
    }
