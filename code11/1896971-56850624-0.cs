    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int> Dependencies { get; set; }
        public bool HasCircularReferences { get; set; } 
    }
