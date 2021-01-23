    /// <summary>
    /// Determines if the source value is contained in the list of possible values.
    /// </summary>
    /// <typeparam name="T">The type of the objects</typeparam>
    /// <param name="value">The source value</param>
    /// <param name="values">The list of possible values</param>
    /// <returns>
    /// 	<c>true</c> if the source value matches at least one of the possible values; otherwise, <c>false</c>.
    /// </returns>
    public static bool In<T>(this T value, params T[] values)
    {
        if (values == null)
            return false;
    
        if (values.Contains<T>(value))
            return true;
    
        return false;
    }
    
    /// <summary>
    /// Determines if the source value is contained in the list of possible values.
    /// </summary>
    /// <typeparam name="T">The type of the objects</typeparam>
    /// <param name="value">The source value</param>
    /// <param name="values">The list of possible values</param>
    /// <returns>
    /// 	<c>true</c> if the source value matches at least one of the possible values; otherwise, <c>false</c>.
    /// </returns>
    public static bool In<T>(this T value, IEnumerable<T> values)
    {
        if (values == null)
            return false;
    
        if (values.Contains<T>(value))
            return true;
    
        return false;
    }
    
    /// <summary>
    /// Determines if the source value is not contained in the list of possible values.
    /// </summary>
    /// <typeparam name="T">The type of the objects</typeparam>
    /// <param name="value">The source value</param>
    /// <param name="values">The list of possible values</param>
    /// <returns>
    /// 	<c>false</c> if the source value matches at least one of the possible values; otherwise, <c>true</c>.
    /// </returns>
    public static bool NotIn<T>(this T value, params T[] values)
    {
        return In(value, values) == false;
    }
    
    /// <summary>
    /// Determines if the source value is not contained in the list of possible values.
    /// </summary>
    /// <typeparam name="T">The type of the objects</typeparam>
    /// <param name="value">The source value</param>
    /// <param name="values">The list of possible values</param>
    /// <returns>
    /// 	<c>false</c> if the source value matches at least one of the possible values; otherwise, <c>true</c>.
    /// </returns>
    public static bool NotIn<T>(this T value, IEnumerable<T> values)
    {
        return In(value, values) == false;
    }
