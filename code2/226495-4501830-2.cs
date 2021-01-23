    public interface IFoo
    {
        int Add(int a, int b);
    }
    
    public class Foo : IFoo
    {
        private readonly string _foo;
        public Foo(string foo)
        {
            _foo = foo;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
