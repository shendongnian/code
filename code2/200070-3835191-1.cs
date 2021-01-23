      TimeSpan CalcBusinessTime(DateTime a, DateTime b)
      {
         if (a > b)
         {
            DateTime tmp = a;
            a = b;
            b = tmp;
         }
         TimeSpan sum = new TimeSpan();
         if (a.TimeOfDay < new TimeSpan(7, 0, 0))
            a = new DateTime(a.Year, a.Month, a.Day, 7, 0, 0);
         if (a.TimeOfDay < new TimeSpan(19, 0, 0))
            sum += new DateTime(a.Year, a.Month, a.Day, 19, 0, 0) - a;
         while (a.Date < b.Date)
         {
            if (a.DayOfWeek != DayOfWeek.Saturday && a.DayOfWeek != DayOfWeek.Sunday)
            {
               sum.Add(new TimeSpan(12, 0, 0));
            }
            a.AddDays(1);
         }
         if (b.TimeOfDay > new TimeSpan(19, 0, 0))
            b = new DateTime(b.Year, b.Month, b.Day, 19, 0, 0);
         if (b.TimeOfDay > new TimeSpan(7, 0, 0))
            sum += b - a;
         return sum;
      }
