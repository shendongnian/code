    public class TestEntityPerson : BaseEntity<int>
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Age { get; set; }
        public List<TestEntityBook> Books { get; set; }
    }
