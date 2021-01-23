    [InheritedExport(typeof(MyAbstractClass))
    public abstract class MyAbstractClass {
        private readonly IFoo foo;
        public IFoo Foo {
            get {
                Contract.Ensures(Contract.Result<IFoo>() != null);  
                return this.foo;
            }
        }
        
        [ImportingConstructor]
        public MyAbstractClass(IFoo foo) {
            Contract.Requires(foo != null);
            this.foo = foo;
        }
    }
