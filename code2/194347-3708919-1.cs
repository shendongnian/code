    int GetWorkingDays(DateTime startDate, DateTime endDate)
    {
        int count = 0;
        for (DateTime currentDate = startDate; currentDate < endDate; currentDate = currentDate.AddDays(1))
        {
            if (currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday)
            {
                continue;
            }
            count++;
        }
        return count;
    }
