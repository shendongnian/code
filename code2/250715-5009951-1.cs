    readonly Property<int> _myInt = new Property<int>();
    public int MyInt
    {
        get { return _myInt.GetValue(); }
        set { _myInt.SetValue( value, SetterCallbackOption.OnNewValue, SetDirty ); }
    }
    private void SetDirty( int oldValue, int newValue )
    {
        IsDirty = true;
    }
