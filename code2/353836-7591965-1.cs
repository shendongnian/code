    public static bool IsWithinRange<T>(this IEnumerable<T> enumerable, int max)
    {
        var asCollection = enumerable as System.Collections.ICollection;
        if (asCollection != null) return asCollection.Count <= max;
        var asGenericCollection = enumerable as ICollection<T>;
        if (asGenericCollection != null) return asGenericCollection.Count <= max;
        return !enumerable.Skip(max).Any();
    }
