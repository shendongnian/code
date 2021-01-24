    public class Metadata
    {
        public string FirstName { get; set; }
        public string LasstName { get; set; }
    }
    
    public class Data
    {
        public IList<Metadata> Metadata { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
