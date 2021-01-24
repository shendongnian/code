csharp
    public class A
    {
        private B _b;
        public A(B b)
        {
            _b = b;
        }
    }
For B, do not create a public constructor. Use a builder to build it, so every time you get a `B`, there is always a fine instance in it.
csharp
    public class B
    {
        private A _a;
        private B() { }
        public (A, B) Init()
        {
            var b = new B();
            _a = new A(b);
            return (_a, b);
        }
    }
To get it, call:
csharp
var (a, b) = B.Init();
