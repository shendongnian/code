    class Parent
    {
        public Parent(IChild[] children)
        {
            Children = children;
            foreach (var child in children)
            {
                child.Parent = this;
            }
        }
        public IChild[] Children { get; private set; }
    }
    interface IChild
    {
        Parent Parent { get; set;  }
    }
    class Child1 : IChild
    {
        public Parent Parent { get; set; }
    }
