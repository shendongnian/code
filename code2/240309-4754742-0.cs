    public class SomeClassA
    {
        public int foo1;
        public string foo2;
        public SomeClassA(int foo1, string foo2)
        {
            this.foo1 = foo1;
            this.foo2 = foo2;
        }
    }
    public class SomeClassB : SomeClassA
    {
        public SomeClassB(int arg1, string arg2)
            : base(arg1, arg2)
        { }
    }
