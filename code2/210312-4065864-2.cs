    public IList<int> GetWeekNumbers(DateTime startDate, DateTime endDate)
    {
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        var result = new List<int>();
    
        for (DateTime tm = startDate; tm <= endDate; tm = tm.AddDays(7))
        {
          result.Add(currentCulture.Calendar.GetWeekOfYear(tm, dfi.CalendarWeekRule, 
                                                  dfi.FirstDayOfWeek));
        }
        return result;
    }
