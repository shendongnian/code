    public class TimeCard
    {
        public DateTime StartDate { get; set; }
    
        [GreaterThanDateAttribute("StartDate")]
        public DateTime EndDate { get; set; }
    }
