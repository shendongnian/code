    public class Parent
    {
        public Child Child { get; private set; }
        public string Name { get; set; }
        public Parent()
        {
            Child = new Child(this);
        }
    }
    public class Child
    {
        private readonly Parent parent;
        public string Name { get; set; }
        public Child(Parent parent)
        {
            this.parent = parent;
        }
    }
