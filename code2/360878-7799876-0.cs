    [field: NonSerialized]
    private MyType _MyProperty;
    
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public MyType MyProperty
    {
        get
        {
            return _MyProperty;
        }
        set
        {
            _MyProperty = value;
        }
    }
