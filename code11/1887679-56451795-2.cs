    public class ServiceSchedule
    {
        public DateTime LastServiced { get; set; } = new DateTime(2019, 01, 01);
        public TimeSpan ServiceInterval { get; set; } = TimeSpan.FromDays(180);
        public DateTime NextService => LastServiced.Add(ServiceInterval);
        public bool IsOverdueForService => DateTime.Today > NextService;
    }
