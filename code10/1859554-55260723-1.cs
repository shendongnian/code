    public class Child
    {
        public virtual List<ChildItem> Items { get; set; } //why virtual? you planning to inherit?
        public string Name {get; set; }
        public int Id {get; set; }
        public int ParentId {get; set; }
    }
