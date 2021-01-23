    public static DateTime GetThirdFriday(int year, int month)
    {
       DateTime baseDay = new DateTime(year, month, 15);
       int thirdfriday = 15 + ((12 - (int)baseDay.DayOfWeek) % 7);
       return new DateTime(year, month, thirdfriday);
    }
