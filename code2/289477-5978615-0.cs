    public class MyClass
    {
        public static MyClass<T> Create<T>() where T : class, new()
        {
            return new MyClass<T>(() => new T());
        }
    }
    public class MyClass<T> where T : class
    {
        T obj;
        public MyClass(Allocator allocator)
        {
            obj = allocator();
        }
    }
