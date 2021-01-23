    public class NullFoo : IFoo
    {
        public void Do() {}
    }
    public class Bar
    {
        IFoo foo;
        public Bar(IFoo foo)
        {
            this.foo = foo;
        }
    
        public void Do()
        {
            this.foo.Do();
        }
    }
