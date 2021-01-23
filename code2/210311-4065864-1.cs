    public IList<int> getWeekNumbers(DateTime startDate, DateTime endDate)
    {
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        var result new List<int>();
    
        for (DateTime tm = startDate; tm <= endDate; tm = tm.AddDays(7))
        {
          result.Add(System.Globalization.Calendar.GetWeekOfYear(tm, dfi.CalendarWeekRule, 
                                                  dfi.FirstDayOfWeek));
        }
        return result;
    }
