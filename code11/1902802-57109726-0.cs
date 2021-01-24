    tatic IEnumerable<DateTime> GetAllDatesAndInitializeTickets(DateTime startDate, DateTime endDate)
    {
        List<DateTime> allDates = new List<DateTime>();
    
    
        for (DateTime i = startDate; i <= endDate; i = i.AddDays(45))
        {
            allDates.Add(i);
        }
        return allDates.AsReadOnly();
    }
