    private static DateTime isBankHoliday(DateTime myDate)
    {
        while (DateSystem.IsPublicHoliday(myDate, CountryCode.GB)
                || DateSystem.IsWeekend(myDate, CountryCode.GB))
        {
            myDate = myDate.AddDays(1);
        }
        return myDate;
    }
