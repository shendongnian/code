The purpose of the Lazy feature in .NET 4.0 is to replace a pattern many developers used previously with properties.  The "old" way would be something like
    private MyClass _myProperty;
    public MyClass MyProperty
    {
        get
        {
            if (_myProperty == null)
            {
                _myProperty = new MyClass();
            }
            return _myProperty;
        }
    }
This way, _myProperty only gets instantiated once and only when it is needed.  If it is never needed, it is never instantiated.  To do the same thing with Lazy, you might write
    private Lazy<MyClass> _myProperty = new Lazy<MyClass>( () => new MyClass());
    public MyClass MyProperty
    {
        get
        {
            return _myProperty.Value;
        }
    }
Of course, you are not restricted to doing things this way with Lazy, but the purpose is to specify how to instantiate a value without actually doing so until it is needed.  The calling code does not have to keep track of whether the value has been instantiated; rather, the calling code just uses the Value property.  (It is possible to find out whether the value has been instantiated with the IsValueCreated property.)
