    public System.Collections.Generic.IEnumerable<DateTime> GetDatesBetween(
        DateTime start,
        DateTime end
        )
    {
        DateTime current = start;
        while (current <= end) 
        {
            yield return current.Date;
            current = current.AddDays(1);
        }
    }
