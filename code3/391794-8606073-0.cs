    public interface ISomeInterface
    {
        void DoSomething();
    }
    
    public class MyClass<T> where T : ISomeInterface
    {
        public void doSomething()
        {
           T.DoSomething();
        }
    }
