    public void Test(ref SomeClass obj)
    {
        obj = null;
    }
    public void Test2(SomeClass obj)
    {
        obj = null;
    }
    public void Foo()
    {
        SomeClass obj = new SomeClass();
        Test(ref obj);
        // obj is null here!
        obj = new SomeClass();
        Test2(obj);
        // obj is not null here.
    }
