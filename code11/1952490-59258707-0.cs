    public class MyClass
    {
        public virtual int MyProperty1 { get; private set; }
        public int MyProperty2 { get; private set; }
        public MyClass() { }
        public MyClass(int myProperty2) => MyProperty2 = myProperty2;
    }
