    public class Category   // an instance of the class is just ONE category
    {
        public Int64 Id { get; set; }
        public Category Parent { get; set; }        // A parent link, EF will  handle this for you using an Association
        public List<Category> Children {get; set;}  // Replace this when you move to EF or L2S
        public string Name { get; set; }
        public string Description { get; set; }
    }
