    public class Parent
    {
        public Parent
        {
            Children = new List<Child>();
        }
        public int Id { get; set; }
        public ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        public int Id { get; set; }
    }
