    class TimeObject
    {
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
        public RepeatFrequencyType RepeatFrequencyType { get; set; }
        public int RepeatFrequency { get; set; }
        public DateTime NextStartTime()
        {
            var currentTime = DateTime.UtcNow;
            // Grab the StartTime and add the duration
            var nextTime = StartTime.AddMinutes(DurationInMinutes);
            // Continue to increment it until it's greater than the current time
            while (currentTime >= nextTime)
            {
                switch (RepeatFrequencyType)
                {
                    case RepeatFrequencyType.Minutes:
                        nextTime = nextTime.AddMinutes(RepeatFrequency);
                        break;
                    case RepeatFrequencyType.Hours:
                        nextTime = nextTime.AddHours(RepeatFrequency);
                        break;
                    case RepeatFrequencyType.Days:
                        nextTime = nextTime.AddDays(RepeatFrequency);
                        break;
                    case RepeatFrequencyType.Weeks:
                        nextTime = nextTime.AddDays(RepeatFrequency * 7);
                        break;
                    case RepeatFrequencyType.Months:
                        nextTime = nextTime.AddMonths(RepeatFrequency);
                        break;
                    case RepeatFrequencyType.Years:
                        nextTime = nextTime.AddYears(RepeatFrequency);
                        break;
                    case RepeatFrequencyType.FirstWeekdayOfMonth:
                        nextTime = GetNextFirstWeekdayOfMonth(nextTime.AddMonths(RepeatFrequency));
                        break;
                    default:
                        throw new Exception("Unknown value for RepeatFrequency specified.");
                }
            }
            // Remove the added duration from the return value
            return nextTime.AddMinutes(-DurationInMinutes);
        }
        private DateTime GetNextFirstWeekdayOfMonth(DateTime date)
        {
            // Start at the first day of the month
            var firstWeekday = new DateTime(date.Year, date.Month, 1);
            // While the first day is not a weekday, add a day
            while (firstWeekday.DayOfWeek == DayOfWeek.Saturday ||
                   firstWeekday.DayOfWeek == DayOfWeek.Saturday)
            {
                firstWeekday.AddDays(1);
            }
            // If the specified date is greater than the first weekday,
            // return the first weekday of the next month.
            if (date > firstWeekday)
            {
                firstWeekday = GetNextFirstWeekdayOfMonth(date.AddMonths(1));
            }
            return firstWeekday;
        }
    }
