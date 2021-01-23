    /// <summary>
    /// Converts a gregorian date to its hebrew date string representation,
    /// using custom DateTime format string.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="format">A standard or custom date-time format string.</param>
    public static string ToJewishDateString(this DateTime value, string format)
    {
      var ci = CultureInfo.CreateSpecificCulture("he-IL");
      ci.DateTimeFormat.Calendar = new HebrewCalendar();      
      return value.ToString(format, ci);
    }
