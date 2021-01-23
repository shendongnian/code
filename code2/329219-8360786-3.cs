    public class EventDetailDTO : DescriptionDTO
    {
        public string Code { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public int Client { get; set; }
        public int BreakMinutes { get; set; }
        public int CanBeViewedBy { get; set; } 
    }
