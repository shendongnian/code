    class MyClass
    {
        public override string ToString()
        {
            return "MyClass";
        }
    }
    static void MyMethod(string s) { }
    static void Main(string[] args)
    {
        MyMethod(new MyClass());   //compile error
    }
