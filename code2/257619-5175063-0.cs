    [Export(typeof(IFooService))]
    [Export("Foo1", typeof(IFooService))]
    public class Foo1 : IFooService
    {
        public int Foo() { return 1; }
    }
    
    [Export(typeof(IFooService))]
    [Export("Foo2", typeof(IFooService))]
    public class Foo2 : IFooService
    {
        public int Foo() { return 2; }
    }
