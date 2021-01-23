    /// <summary>
    /// Retrieves the item as the only item in an IEnumerable.
    /// </summary>
    /// <param name="this">The item.</param>
    /// <returns>An IEnumerable containing only the item.</returns>
    public static IEnumerable<TItem> AsEnumerable<TItem>(this TItem @this)
    {
        return new [] { @this };
    }
