    public static List<DateTime> GetDates(int year, int month)
    {
       var dates = new List<DateTime>();
       for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
       {
          dates.Add(date);       
       }
       return dates;
    }
