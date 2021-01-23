    ///----------------------------------------------------------------------
    /// <summary>
    /// Determines whether the specified list contains the matching string value
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="value">The value to match.</param>
    /// <param name="ignoreCase">if set to <c>true</c> the case is ignored.</param>
    /// <returns>
    ///   <c>true</c> if the specified list contais the matching string; otherwise, <c>false</c>.
    /// </returns>
    ///----------------------------------------------------------------------
    public static bool Contains(this List<string> list, string value, bool ignoreCase = false)
    {
        return ignoreCase ?
            list.Any(s => s.Equals(value, StringComparison.OrdinalIgnoreCase)) :
            list.Contains(value);
    }
