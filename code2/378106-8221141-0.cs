    /// <summary>
    /// Utility method for GetDaylightChanges. 
    /// Searches for date defined by TransitionTime structure.
    /// </summary>
    /// <param name="year">Year for which create date.</param>
    /// <param name="transitionTime">TimeZoneInfo.TransitionTime which to use for date calculation.</param>
    /// <returns>Transition time.</returns>
    private static DateTime DateTimeByWeek(int year, TimeZoneInfo.TransitionTime transitionTime)
    {
        const int DaysInWeek = 7;
        // get year and month
        DateTime switchDate = new DateTime(year, transitionTime.Month, 1);
        // move to switch day of week
        while (switchDate.DayOfWeek != transitionTime.DayOfWeek)
        {
            switchDate = switchDate.AddDays(1);
        }
        // move to week
        switchDate = switchDate.AddDays((transitionTime.Week - 1) * DaysInWeek);
        // add time
        switchDate = switchDate.AddHours(transitionTime.TimeOfDay.Hour);
        // sometimes it gives us next month...
        if (switchDate.Month != transitionTime.Month)
        {
            // ...then use previous (last) week
            return switchDate.AddDays(-DaysInWeek);
        }
        return switchDate;
    }
