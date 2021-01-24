    public abstract class MyClass
    {
        protected static string _Shared;
    }
    public class MyClass<T> : MyClass
    {
        public void Set(string value)
        {
            _Shared = value;
        }
    
        public void Get()
        {
            Console.WriteLine(_Shared);
        }
    }
