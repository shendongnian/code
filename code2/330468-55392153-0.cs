    public interface IBar
    {
        int Bar(string s);
    }
    
    public interface IFoo
    {
        int Foo(string s);
    }
    
    public class FooClass : IFoo
    {
        private readonly IBar _bar;
    
        public FooClass(IBar bar)
        {
            _bar = bar;
        }
    
        public int Foo(string s) 
            => _bar.Bar(s);
    }
