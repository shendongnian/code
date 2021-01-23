    class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("A Foo");
        }
    }
    class B : A
    {
        public void Foo()
        {
            Console.WriteLine("B Foo");
        }
    }
    B b = new B();
    b.Foo(); // call 'B Foo'
    A a = (A)b;
    a.Foo(); // call 'A Foo'
