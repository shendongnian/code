    /// <summary>
    /// Determines whether the source string contains the specified value.
    /// </summary>
    /// <param name="source">The String to search.</param>
    /// <param name="toCheck">The search criteria.</param>
    /// <param name="comparisonOptions">The string comparison options to use.</param>
    /// <returns>
    ///   <c>true</c> if the source contains the specified value; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains( this string source, string value, StringComparison comparisonOptions )
    {
        return source.IndexOf( value, comparisonOptions ) >= 0;
    }
