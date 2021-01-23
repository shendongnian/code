    static void Foo(ref object obj)
    {
        obj = new SomeObject();
    }
    static void Bar()
    {
        string s = "";
        Foo(ref s);
    }
