    public static IEnumerable<DateTime> To(this DateTime start, DateTime end)
    {
        Date endDate = end.Date;
        for (DateTime date = start.Date; date <= endDate; date = date.AddDays(1))
        {
            yield return date;            
        }
    }
