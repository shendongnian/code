    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            parent.AddChild();
            Parent childParent = parent.Children[0].Parent;
            parent.AddChild();
        }
    }
    public class Parent
    {
        public List<Child> Children { get; set; }
        public Parent()
        {
            Children = new List<Child>();
        }
        public void AddChild()
        {
            Children.Add(new Child(this));
        }
    }
    public class Child
    {
        public Parent Parent { get; set; }
        public Child(Parent parent)
        {
            Parent = parent;
        }
    }
