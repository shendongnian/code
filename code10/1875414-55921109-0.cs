    private static DateTime isBankHoliday(DateTime myDate)
    {
    
        if (DateSystem.IsPublicHoliday(myDate, CountryCode.GB) || DateSystem.IsWeekend(myDate, CountryCode.GB))
        {
            return isBankHoliday(myDate.AddDays(1));
        }
        else
        {
            return myDate;
        }
    }
