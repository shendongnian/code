    private int _field
    public int Property
    {
        get{ return _field;}
        set{
            if (Enum.GetValues(typeof(SomeEnum))).Contains(value))
                _field = value;
            else 
                _field = 0;
            }
    }
