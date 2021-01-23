    /// <summary>
    /// Returns an IEnumerable<T> as is, or an empty IEnumerable<T> if it is null
    /// </summary>
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
    {
        return source ?? Enumerable.Empty<T>();
    }    
  
