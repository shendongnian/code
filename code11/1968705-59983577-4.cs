    public TimeSpan GetHoursForDay(DateTime day) {
        // shouldWorkTime should have been sorted once for all at creation.
        // This code use the first acceptable Valid_from
        // By using OrderByDescending we take the last (in date) entry
        var math = shouldWorkTime
                     .Where(v => day >= v.Valid_from) // We take only valid entry
                     .OrderByDescending(v => v.Valid_from) // We sort only on valid entry
                     .FirstOrDefault(); // we take the last (in date) valid entry
    
        if (match == null)
            return TimeSpan.Zero;
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return match.ShouldWorkMonday;
            case DayOfWeek.Tuesday:
                return match.ShouldWorkTuesday;
            case DayOfWeek.Wednesday:
                return match.ShouldWorkWednesday;
            case DayOfWeek.Thursday:
                return match.ShouldWorkThursday;
            case DayOfWeek.Friday:
                return match.ShouldWorkFriday;
            case DayOfWeek.Saturday:
                return match.ShouldWorkSaturday;
            case DayOfWeek.Sunday:
                return match.ShouldWorkSunday;
        }
    }
