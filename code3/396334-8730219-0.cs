    public class MyClass
    {
        public MyClass Reset()
        {
            return new MyClass();
        }
    }
    MyClass c = new MyClass();
    c = c.Reset();
