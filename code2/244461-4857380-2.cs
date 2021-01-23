    partial void Foo(ref int result);
    partial void Foo(ref int result)
    {
        result = 42;
    }
    
    public void Test()
    {
        int i = 0;
        Foo(ref i);
        // 'i' is 42.
    }
