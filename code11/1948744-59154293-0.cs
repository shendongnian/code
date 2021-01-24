    public class MyClass
    {
        private Lazy<MyObjectClass> lazyObjectClass = new Lazy<MyObjectClass>(() => new MyObjectClass());
    
        public MyObjectClass MyObject { get { return lazyObjectClass.Value;** } }
    }
