    public class Answer
    {
        public string Status { get; set; }
        public List<Domain> Data { get; set; }
    }
    public class Domain
    {
        public int Id { get; set; }
        public string DomainTitle { get; set; }
        public bool IsDeleted { get; set; }
    }
