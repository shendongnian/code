    public class MyClass
    {
        public MyClass() {/*Heavy initialization*/}
        public int MyProperty { get; set; }
    }
    public class Example
    {
        Lazy<MyClass> _lazyInstance = new Lazy<MyClass>(() => new MyClass());
        public MyClass MyInstance
        {
            get { return _lazyInstance.Value; }
            set { _lazyInstance = new Lazy<MyClass>(() => value); }
        }
    }
