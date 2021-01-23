    /// <summary>
    /// Returns a sequence containing one element.
    /// </summary>
    public static IEnumerable<T> AsEnumerable<T>(this T obj)
    {
        yield return obj;
    }  
