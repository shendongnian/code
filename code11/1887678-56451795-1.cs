    public class ServiceSchedule
    {
        public DateTime LastServiced { get; set; } = new DateTime(2019, 01, 01);
        public TimeSpan MaxServiceInterval { get; set; } = TimeSpan.FromDays(90);
        public bool IsOverdueForService => DateTime.Today > LastServiced.Add(MaxServiceInterval);
    }
