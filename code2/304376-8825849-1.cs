    /// <summary>
    /// Determines whether or not the EventEntry is set as Busy.
    /// </summary>
    /// <param name="entry">The Google EventEntry.</param>
    public static bool IsBusy(this EventEntry entry)
    {
        return entry.EventTransparency.Value.Equals("http://schemas.google.com/g/2005#event.opaque");
    }
