    class Parent
    {
        public Parent(IChild[] children)
        {
            Children = children;
        }
        public IChild[] Children { get; private set; }
    }
    interface IChild
    {
        Parent Parent { get; }
    }
    class Child1 : IChild
    {
        public Child1(Parent parent)
        {
            Parent = parent;
        }
        public Parent Parent { get; private set; }
    }
