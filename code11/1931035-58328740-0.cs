    public class BaseClass
    {
        public BaseClass(Dependency dep) {}
    }
    public class ChildClass
    {
        public ChildClass(Dependency dep) : base(dep) {}
    }
