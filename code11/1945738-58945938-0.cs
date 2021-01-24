    public class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
    public class Request
    {
        public int RequestId { get; set; }
        public string  Description { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
 
