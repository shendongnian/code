    List<DateTime> GetEvents(DateTime start, DateTime end)
    {
        List<DateTime> events = new List<DateTime>();
        
        DateTime e = start;
        while(e <= end)
        {
             e = e.AddDays(7);
             events.Add(e);
        }
        return events;
    }
