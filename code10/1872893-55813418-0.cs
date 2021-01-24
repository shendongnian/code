    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Child1> Child1s { get; set; }
    }
     public class Child1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public virtual List<Child2> Child2s { get; set; }
    }
    public class Child2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Child1Id { get; set; }
        public Child1 Child1 { get; set; }
    }
