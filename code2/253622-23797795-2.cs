    public static bool ContainsDuplicates<T>(this IEnumerable<T> enumerable)
    {
        var knownKeys = new HashSet<T>();
        return enumerable.Any(item => !knownKeys.Add(item));
    }
