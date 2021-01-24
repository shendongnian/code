    public class FullName
    {
        public string FirstName { get; set; }
        public string LasstName { get; set; }
    }
    
    public class Data
    {
        public IList<FullName> Metadata { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
