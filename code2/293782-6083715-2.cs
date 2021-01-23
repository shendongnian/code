    /// <summary>
    /// Truncates a string to a maximum length.
    /// </summary>
    /// <param name="value">The string to truncate.</param>
    /// <param name="length">The maximum length of the returned string.</param>
    /// <returns>The input string, truncated to <paramref name="length"/> characters.</returns>
    public static string Truncate(this string value, int length)
    {
    	if (value == null)
    		throw new ArgumentNullException("value");
    	return value.Length <= length ? value : value.Substring(0, length);
    }
