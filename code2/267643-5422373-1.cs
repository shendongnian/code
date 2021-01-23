    public static DateTime GetThirdFriday(int year, int month)
    {
       DateTime firstDay = new DateTime(year, month, 15);
       int thirdfriday = 15 + ((12 - (int)firstDay.DayOfWeek) % 7);
       return new DateTime(year, month, thirdfriday);
    }
