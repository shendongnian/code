    public class Friends
    {
        public string Timestamp { get; set; }
        public string Event { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
    public class Commander
    {
        public string Timestamp { get; set; }
        public string Event { get; set; }
        public string FID { get; set; }
        public string Name { get; set; }
    }
    public class Materials
    {
        public string Timestamp { get; set; }
        public string Event { get; set; }
        public List<Material> Raw { get; set; }
    }
    public class Material
    {
        public string Name { get; set; }
        public string Count { get; set; }
    }
