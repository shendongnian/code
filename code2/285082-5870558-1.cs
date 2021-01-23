    private Type2 _valueThatIsStoredAsAResultOfCallMethod;
    private Type2 CallMethod(Type1 value)
    {
        // Whatever logic is required here to take a value of Type1 and
        // get a value of Type2 from it
        return value.ToType2();
    }
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
