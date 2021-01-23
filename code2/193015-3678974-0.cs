    public class Category   // an instance of the class is just ONE category
    {
        public Int64 Id { get; set; }
        public Category Parent { get; set; }  // a parent link
        public string Name { get; set; }
        public string Description { get; set; }
    }
