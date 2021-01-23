    public DateTime FirstMonday(int year)
    {
        DateTime firstDay = new DateTime(year, 1, 1);
        return new DateTime(year, 1, (8 - (int)firstDay.DayOfWeek) % 7 + 1);
    }
