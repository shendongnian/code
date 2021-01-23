    /// <summary>
    /// Converts a string formatted as an expanded XML name ({namespace}localname) to an XName object. 
    /// </summary>
    /// <param name="expandedName">A string containing an expanded XML name in the format: {namespace}localname.</param> 
    /// <returns>An XName object constructed from the expanded name.</returns> 
    [CLSCompliant(false)]
    public static implicit operator XName(string expandedName) { 
        return expandedName != null ? Get(expandedName) : null;
    }
