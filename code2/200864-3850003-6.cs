    public static List<DateTime> GetDates(int year, int month)
    {
       var dates = new List<DateTime>();
       // Loop from the first day of the month until we hit the next month, moving forward a day at a time
       for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
       {
          dates.Add(date);       
       }
       return dates;
    }
