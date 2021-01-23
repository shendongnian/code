    private readonly ThreadLocal<MyClass> _someProperty = new ThreadLocal<MyClass>();
    public MyClass SomeProperty
    {
        get { return _someProperty.Value; }
        set { _someProperty.Value = value; }
    }
