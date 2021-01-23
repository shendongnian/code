    public Type1
    {
        set
        {
            // value is of type Type1
            _valueThatIsStoredAsAResultOfCallMethod = CallMethod(value);
        }
    }
    
    public Type2
    {
        get
        {
            return _valueThatIsStoredAsAResultOfCallMethod;
        }
    }
