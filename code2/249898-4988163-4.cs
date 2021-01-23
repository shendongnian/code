     namespace DateTime.Extensions
     {
       public static class DateTimeExtensions
       {
         public static DateTime Next(this DateTime now, DayOfWeek nextDay)
         {
            do {
              now = now.AddDays(1);
            } while (now.DayOfWeek != nextDay)
            return now;
          }
       }
     }
