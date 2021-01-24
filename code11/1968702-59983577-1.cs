    public TimeSpan GetHoursForDay(DateTime day) {
        // shouldWorkTime should have been sorted once for all at creation.
        // This code use the first acceptable Valid_from
        // Use OrderByDescending if you want the for last acceptable Valid_from
        foreach (var times in shouldWorkTime.OrderBy(v => v.Valid_from))
        {
            if (times.Valid_from > day) 
                continue;
            
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return times.ShouldWorkMonday;
                case DayOfWeek.Tuesday:
                    return times.ShouldWorkTuesday;
                case DayOfWeek.Wednesday:
                    return times.ShouldWorkWednesday;
                case DayOfWeek.Thursday:
                    return times.ShouldWorkThursday;
                case DayOfWeek.Friday:
                    return times.ShouldWorkFriday;
                case DayOfWeek.Saturday:
                    return times.ShouldWorkSaturday;
                case DayOfWeek.Sunday:
                    return times.ShouldWorkSunday;
            }
        }
        return TimeSpan.Zero;
    }
