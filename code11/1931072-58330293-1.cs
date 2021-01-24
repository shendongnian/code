    public interface IFoo
    {
        void f(int i);
        void f(string s);
    }
    public class A : IFoo
    {
        ...  
    }
    public class B
    {
        public IFoo A => _a;
    }
