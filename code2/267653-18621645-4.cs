    public static bool TryGetDayOfMonth(this DateTime instance, 
                                     DayOfWeek dayOfWeek, 
                                     int occurance, 
                                     out DateTime dateOfMonth)
    {
        if (instance == null)
        {
            throw new ArgumentNullException("instance");
        }
        if (occurance <= 0 || occurance > 5)
        {
            throw new ArgumentOutOfRangeException("occurance", "Occurance must be greater than zero and less than 6.");
        }
        bool result;
        dateOfMonth = new DateTime();
        // Change to first day of the month
        DateTime dayOfMonth = instance.AddDays(1 - instance.Day);
        // Find first dayOfWeek of this month;
        if (dayOfMonth.DayOfWeek > dayOfWeek)
        {
            dayOfMonth = dayOfMonth.AddDays(7 - (int)dayOfMonth.DayOfWeek + (int)dayOfWeek);
        }
        else
        {
            dayOfMonth = dayOfMonth.AddDays((int)dayOfWeek - (int)dayOfMonth.DayOfWeek);
        }
        // add 7 days per occurance
        dayOfMonth = dayOfMonth.AddDays(7 * (occurance - 1));
        // make sure this occurance is within the original month
        result = dayOfMonth.Month == instance.Month;
            
        if (result)
        {
            dateOfMonth = dayOfMonth;
        }
        return result;
    }
