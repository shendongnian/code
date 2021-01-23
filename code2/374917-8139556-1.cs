    [InheritedExport(typeof(MyAbstractClass))
    public abstract class MyAbstractClass {
        private readonly IFoo foo;
        public IFoo Foo {
            get {
                Contract.Ensures(Contract.Result<IFoo>() != null);  
                return this.foo;
            }
        }
        
        protected MyAbstractClass(IFoo foo) {
            Contract.Requires(foo != null);
            this.foo = foo;
        }
    }
    public class MyClass : MyAbstractClass
    {
        [ImportingConstructor]
        public MyClass(IFoo foo) : base(foo) { }
    }
