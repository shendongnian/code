      TimeSpan CalcBusinessTime(DateTime a, DateTime b)
      {
         if (a > b)
         {
            DateTime tmp = a;
            a = b;
            b = tmp;
         }
         if (a.TimeOfDay < new TimeSpan(7, 0, 0))
            a = new DateTime(a.Year, a.Month, a.Day, 7, 0, 0);
         if (b.TimeOfDay > new TimeSpan(19, 0, 0))
            b = new DateTime(b.Year, b.Month, b.Day, 19, 0, 0);
         TimeSpan sum = new TimeSpan();
         TimeSpan fullDay = new TimeSpan(12, 0, 0);
         while (a < b)
         {
            if (a.DayOfWeek != DayOfWeek.Saturday && a.DayOfWeek != DayOfWeek.Sunday)
            {
               sum += (b - a < fullDay) ? b - a : fullDay;
            }
            a = a.AddDays(1);
         }
         return sum;
      } 
