    public class WorkingTimeScheldure
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Dictionary<DayOfWeek, TimeSpan> Scheldure { get; set; }
    }
