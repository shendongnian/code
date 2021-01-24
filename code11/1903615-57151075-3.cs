    class TimeObject
    {
        public DateTime StartTime { get; set; }
        public int DurationInMinutes { get; set; }
        public RepeatFrequencyType RepeatFrequency { get; set; }
        public DateTime NextStartTime()
        {
            var currentTime = DateTime.UtcNow;
            // Grab the current StartTime and add the duration
            var nextTime = StartTime.AddMinutes(DurationInMinutes);
            // Continue to increment it until it's greater than the current time
            while (currentTime >= nextTime)
            {
                switch (RepeatFrequency)
                {
                    case RepeatFrequencyType.Minutes:
                        nextTime = nextTime.AddMinutes(1);
                        break;
                    case RepeatFrequencyType.Hours:
                        nextTime = nextTime.AddHours(1);
                        break;
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
            // Remove the added duration from the return value
            return nextTime.AddMinutes(-DurationInMinutes);
        }
    }
