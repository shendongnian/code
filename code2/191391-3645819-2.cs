    /// <summary>
    /// Returns a sequence containing one element.
    /// </summary>
    public static IEnumerable<T> AsIEnumerable<T>(this T obj)
    {
        yield return obj;
    }  
