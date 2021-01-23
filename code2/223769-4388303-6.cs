    DateTime AddBusinessDay(DateTime start, int count, IEnumerable<DateTime> holidays) {
       int daysToAdd = count + ((count/ 5) * 2) + (((start.DayOfWeek + (count % 5)) >= 5) ? 2 : 0);
       var end = start.AddDays(daysToAdd);
       foreach(var dt in holidays) {
         if (dt >= start && dt <= end) {
            end = end.AddDays(1);
            if (end.DayOfWeek == DayOfWeek.Saterday) {
              end = end.AddDays(2);
            }
         }
       }
       return end;
    }    
