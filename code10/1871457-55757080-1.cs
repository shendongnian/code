    public class TestEntityBook : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        
        public Guid TestEntityPersonId { get; set; }
        
        // The problematic property
        public TestEntityPerson TestEntityPerson { get; set; }
    }
