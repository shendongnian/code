    public class TypedList
    {
        public Guid ObjectId { get; set; }
    
        private readonly List<string> items = new List<string>();
        public List<string> Items { get { return items; } }
    }
