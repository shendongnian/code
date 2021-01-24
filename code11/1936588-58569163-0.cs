    public class Root
    {
        public int Id { get; set; }
        public string text { get; set; }
        public List<Child> children { get; set; } = new List<Child>();
    }
