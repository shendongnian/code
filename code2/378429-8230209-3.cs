    class Bar : IBar
    {
        Foo foo = new Foo();
    
        public void X() { }   
    
        public void DoSomething()
        {
            this.Foo.M(); // invokes method of instance of nested class
        }
    
        class Foo : IFoo
        {
            public void M() { } 
        }
    }
