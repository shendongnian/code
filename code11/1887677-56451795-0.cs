    public class Service
    {
        public DateTime LastServiced { get; set; }
        public TimeSpan MaxServiceInterval { get; set; } = TimeSpan.FromDays(180);
        public bool IsOverdueForService => DateTime.Now > LastServiced.Add(MaxServiceInterval);
    }
