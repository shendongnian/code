    public interface IFoo
    {
        void Do();
    }
    
    public class Foo : IFoo
    {
        public void Do()
        {
           DoSomething();
        }
    }
    
    public class UglyNullCheckingBar
    {
        IFoo foo;
        public Bar(IFoo foo)
        {
            this.foo = foo;
        }
    
        public void Do()
        {
            if (this.foo != null)
            {
                this.foo.Do();
            }
        }
    }
