    public class MyClass
    {
        public delegate int DoSomethingImpl(int foo, int bizBar);
        public DoSomethingImpl DoSomething = (x, y) => { return x + y; }
    }
