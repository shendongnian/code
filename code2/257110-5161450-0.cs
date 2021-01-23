    [Export("Foo100", typeof(IFooService))]
    public sealed class Foo100 : IFooService
    {
        public Int32 GetFoo()
        {
            return 100;
        }
    }
    
    
    [Export("Foo200", typeof(IFooService))]
    public sealed class Foo200 : IFooService
    {
        public Int32 GetFoo()
        {
            return 200;
        }
    }
-
    [Import("Foo100", typeof(IFooService)]
    private IFooService FooSvc { get; set; }
