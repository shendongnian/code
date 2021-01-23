    public IPredefinedInterface<T>
    {
        void DoSomething(T obj);
    }
    
    public class MyClass<T> : IPredefinedInterface<T>
    {
        public void DoSomething(T obj)
        {
    
            SomeOtherFunc((T)obj);
        }
    }
