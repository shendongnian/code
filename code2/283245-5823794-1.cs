    delegate void MethodDelegate(int val);
    void Foo(MethodDelegate m)
    {
        int a = 5;
        m(a);
    }
    void RegularFoo()
    {
        Foo(val => // Or: Foo(delegate(int val)
        {
            Console.WriteLine(val);
        });
    }
