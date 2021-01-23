    /// <summary>
    /// Finds the next date whose day of the week equals the specified day of the week.
    /// </summary>
    /// <param name="startDate">
    /// The date to begin the search.
    /// </param>
    /// <param name="desiredDay">
    /// The desired day of the week whose date will be returneed.
    /// </param>
    /// <returns>
    /// The returned date is on the given day of this week.
    /// If the given day is before given date, the date for the
    /// following week's desired day is returned.
    /// </returns>
    public static DateTime GetNextDateForDay( DateTime startDate, DayOfWeek desiredDay )
    {
        // (There has to be a better way to do this, perhaps mathematically.)
        // Traverse this week
        DateTime nextDate = startDate;
        while( nextDate.DayOfWeek != desiredDay )
            nextDate = nextDate.AddDays( 1D );
        return nextDate;
    }
