    /// <summary>
    ///   Returns whether the object equals any of the given values.
    /// </summary>
    /// <param name = "source">The source for this extension method.</param>
    /// <param name = "toCompare">The objects to compare with.</param>
    /// <returns>
    ///   True when the object equals any of the passed objects, false otherwise.
    /// </returns>
    public static bool EqualsAny( this object source, params object[] toCompare )
    {
        return toCompare.Any( o => o.Equals( source ) );
    }
