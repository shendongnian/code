    public class IncidentTrend
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<IncidentsByType> IncidentsByType { get; set; }
    }
    
    public class IncidentsByType
    {
        public int Total { get; set; }
        public string Name { get; set; }
    }
    
    public class IncidentRiskMatrix
    {
        public DateTime Date { get; set; }
        public string IncidentName { get; set; }
    }
