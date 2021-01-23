    public static double GetDeltaMonths(DateTime t0, DateTime t1)
    {
         DateTime t = t0;
         double months = 0;
         while(t<=t1)
         {
             int daysInMonth = DateTime.DaysInMonth(t.Year, t.Month);
             DateTime endOfMonth = new DateTime(t.Year, t.Month, daysInMonth);
             int cutDay = endOfMonth <= t1 ? daysInMonth : t1.Day;
             months += (cutDay - t.Day + 1) / (double) daysInMonth;
             t = new DateTime(t.Year, t.Month, 1).AddMonths(1);
         }
         return Math.Round(months,2);
     }
