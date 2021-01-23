    public static class Utilities
    {
        public static bool ContainsDuplicates<T>(this IEnumerable<T> enumerable)
        {
            var knownKeys = new HashSet<T>();
            foreach (T item in enumerable) {
                if (knownKeys.Contains(item)) 
                    return true;
                knownKeys.Add(item);
            }
            return false;
        }
    }
