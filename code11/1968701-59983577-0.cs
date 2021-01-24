    public TimeSpan GetHoursForDay(DateTime day) {
        foreach (var times in shouldWorkTime /*.OrderBy(v => v.Valid_from)*/ ) // shouldWorkTime should be sorted once for all
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
