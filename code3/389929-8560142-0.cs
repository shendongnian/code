    /// <summary>Indicates whether the specified array is null or has a length of zero.</summary>
    /// <param name="array">The array to test.</param>
    /// <returns>true if the array parameter is null or has a length of zero; otherwise, false.</returns>
    public static bool IsNullOrEmpty(this Array array)
    {
        return (array == null || array.Length == 0);
    }
