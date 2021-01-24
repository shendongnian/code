    class A
    {
        protected void Method1()
        {
        }
        protected void Method2()
        {
        }
    }
    class B: A
    {
        public new void Method1()
        {
            base.Method1();
        }
    }
    class C : A
    {
        public new void Method2()
        {
            base.Method2();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.Method1(); // Not allowed
            a.Method2(); // Not allowed
            B b = new B();
            b.Method1();
            b.Method2(); // Not allowed
            C c = new C();
            c.Method1(); // Not allowed
            c.Method2();
        }
    }
