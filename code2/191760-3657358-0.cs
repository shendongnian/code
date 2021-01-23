     [Export]
        public class Bar
        {
            [ImportingConstructor]
            public Bar([Import("Foo", typeof(IFoo))]IFoo foo)
            //public Bar([Import(typeof(IFoo))]IFoo foo)
            {
                this.Foo = foo;
            }
    
            public IFoo Foo { get; set;}
        }
    
        [Export("Foo", typeof(IFoo))]
        public class Foo : IFoo
        {
            public Foo()
            {
                Message = ":-)";
            }
            public string Message { get; set; }
        }
