    public List<DateTime> DateInstances(DateTime start, DateTime end, DayOfWeek day, int weeks)
    {
        if (start > end)
            throw new ArgumentOutOfRangeException("end", "The start date must occur before the end date");
    
        List<DateTime> results = new List<DateTime>();
    
        DateTime temp = start;
        while (temp < end)
        {
            DateTime firstWeekday = new DateTime(temp.Year, temp.Month, 1);
    
            //increment to the given day (i.e. if we want the 4th sunday, we must find the first sunday of the month)
            while (firstWeekday.DayOfWeek != day)
                firstWeekday = firstWeekday.AddDays(1);
    
            //add the number of weeks (note: we already have the first instance, so subtract 1)
            firstWeekday = firstWeekday.AddDays(7 * (weeks - 1));
    
            //make sure we haven't gone over to the next month
            if (firstWeekday.Month == temp.Month)
                results.Add(firstWeekday);
    
            //let's not loop forever ;)
            temp = temp.AddMonths(1);
        }
    
        return results;
    }
