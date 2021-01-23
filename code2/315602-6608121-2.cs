    DateTime GetFromGps(int weeknumber, double seconds)
    {
        DateTime datum = new DateTime(1980,1,6,0,0,0);
        DateTime week = datum.AddDays(weeknumber * 7);
        DateTime time = week.AddSeconds(seconds);
        return time;
    }
