    public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
      {
         // get the difference from the weekday
         int diff = dt.DayOfWeek - weekday;
         
         // amounttoshow * 7 is the number of days in a week (28 to get 4 weeks)
         var days =
             Enumerable.Range(1, amounttoshow * 7 + diff).Select(            
                 day => DayOfYear(dt, day));
         var weekdays = from day in days
                        where day.DayOfWeek == weekday
                        orderby day.Day ascending
                        select day;
         return weekdays.Take(amounttoshow);
      }
      // returns the day in datetime
      public static DateTime DayOfYear(DateTime dt, int day)
      {
         DateTime firstDayOfYear = new DateTime(dt.Year, 1, 1);
         DateTime dateTime = firstDayOfYear.AddDays(dt.DayOfYear - 1 + day);
         return dateTime;
      }
