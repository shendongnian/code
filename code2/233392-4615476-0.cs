    /// <summary>
    /// Adds weekdays to date
    /// </summary>
    /// <param name="value">DateTime to add to</param>
    /// <param name="weekdays">Number of weekdays to add</param>
    /// <returns>DateTime</returns>
    public static DateTime AddWeekdays(this DateTime value, int weekdays)
    {
        int direction = Math.Sign(weekdays);
        int initialDayOfWeek = Convert.ToInt32(value.DayOfWeek);
        //---------------------------------------------------------------------------
        // if the day is a weekend, shift to the next weekday before calculating
        if ((value.DayOfWeek == DayOfWeek.Sunday && direction < 0)
            || (value.DayOfWeek == DayOfWeek.Saturday && direction > 0))
        {
            value = value.AddDays(direction * 2);
            weekdays += (direction * -1); // adjust days to add by one
        }
        else if ((value.DayOfWeek == DayOfWeek.Sunday && direction > 0)
            || (value.DayOfWeek == DayOfWeek.Saturday && direction < 0))
        {
            value = value.AddDays(direction);
            weekdays += (direction * -1); // adjust days to add by one
        }
        //---------------------------------------------------------------------------
        int weeksBase = Math.Abs(weekdays / 5);
        int addDays = Math.Abs(weekdays % 5);
        int totalDays = (weeksBase * 7) + addDays;
        DateTime result = value.AddDays(totalDays * direction);
        //---------------------------------------------------------------------------
        // if the result is a weekend, shift to the next weekday
        if ((result.DayOfWeek == DayOfWeek.Sunday && direction > 0)
            || (result.DayOfWeek == DayOfWeek.Saturday && direction < 0))
        {
            result = result.AddDays(direction);
        }
        else if ((result.DayOfWeek == DayOfWeek.Sunday && direction < 0)
            || (result.DayOfWeek == DayOfWeek.Saturday && direction > 0))
        {
            result = result.AddDays(direction * 2);
        }
        //---------------------------------------------------------------------------
        return result;
    }
