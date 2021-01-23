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
        if ((value.DayOfWeek == DayOfWeek.Sunday && direction == -1)
            || (value.DayOfWeek == DayOfWeek.Saturday && direction == 1))
        {
            value = value.AddDays(direction * 2);
            weekdays += (direction * -1); // adjust days to add by one
        }
        else if ((value.DayOfWeek == DayOfWeek.Sunday && direction == 1)
            || (value.DayOfWeek == DayOfWeek.Saturday && direction == -1))
        {
            value = value.AddDays(direction);
            weekdays += (direction * -1); // adjust days to add by one
        }
        //---------------------------------------------------------------------------
        int weeksBase = Math.Abs(weekdays / 5);
        int addDays = Math.Abs(weekdays % 5);
        if ((direction == 1 & addDays + initialDayOfWeek > 5)
            || (direction == -1 & addDays >= initialDayOfWeek))
        {
            addDays += 2;
        }
        int totalDays = (weeksBase * 7) + addDays;
        return value.AddDays(totalDays * direction);
    }
