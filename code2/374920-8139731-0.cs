    [InheritedExport(typeof(MyAbstractClass))
    public abstract class MyAbstractClass
    {
        [ImportingConstructor]
        protected MyAbstractClass(IFoo foo)
        {
            //BONUS! Null check here instead...
            if (foo == null) throw new NullArgumentException("foo");
            Foo = foo;
        }
        protected IFoo Foo { get; private set; }
    }
    public sealed MyClass : MyAbstractClass
    {
        [ImportingConstructor]
        public MyClass(IFoo foo) : base(foo) { }
    public void DoSomething()
    {
        var = Foo.GetBar();
        //etc.
    }
