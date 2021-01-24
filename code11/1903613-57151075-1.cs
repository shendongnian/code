    class TimeObject
    {
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
        public RepeatFrequencyType RepeatFrequency { get; set; }
        public DateTime NextStartTime()
        {
            var currentTime = DateTime.UtcNow;
            // Grab the current StartTime + duration
            var nextTime = StartTime.AddMinutes(DurationInMinutes);
            // Continue to increment it until it's greater than or equal to the current time
            while (currentTime >= nextTime)
            {
                switch (RepeatFrequency)
                {
                    case RepeatFrequencyType.Days:
                        nextTime = nextTime.AddDays(1);
                        break;
                    case RepeatFrequencyType.Months:
                        nextTime = nextTime.AddMonths(1);
                        break;
                    case RepeatFrequencyType.Years:
                        nextTime = nextTime.AddYears(1);
                        break;
                    default:
                        throw new Exception("Unknown value for RepeatFrequency specified.");
                }
            }
            // Remove the added duration from the final value
            return nextTime.AddMinutes(-DurationInMinutes);
        }
    }
