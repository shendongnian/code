    public static DateTime NthOf(this DateTime CurDate, int Occurrence , DayOfWeek Day)
     {
         var fday = new DateTime(CurDate.Year, CurDate.Month, 1);
    
         var fOc = fday.DayOfWeek == Day ? fday : fday.AddDays(Day - fday.DayOfWeek);
         
         if (fOc.Month < CurDate.Month) Occurrence = Occurrence+1;
         return fOc.AddDays(7 * (Occurrence - 1));
     }
