    public class InspectionPoint
    {
        // only has "get"ter - therefore it's readonly 
        public DateTime CreateDate { get; }      
        // Every other field has both "get" and "set" and can be set to new values
        public string Detail { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public DateTime UpdateDate { get; set; }
    }
