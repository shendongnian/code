    public class MyClass<T> where T : new()
    {
        protected T GetObject()
        {
            return new T();
        }
    }
