    /// <summary>
    /// Requires finding element by FindElementSafe(By).
    /// Returns T/F depending on if element is defined or null.
    /// </summary>
    /// <param name="element">Current element</param>
    /// <returns>Returns T/F depending on if element is defined or null.</returns>
    public static bool Exists(this IWebElement element)
    {
    	if (element == null)
    	{ return false; }
    	return true;
    }
