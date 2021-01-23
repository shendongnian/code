    private WriteOnce<int> _someInt = default(WriteOnce<int>);
    public int SomeInt
    { 
        get { return _someInt; }
        set { _someInt.Value = value; }
    }
