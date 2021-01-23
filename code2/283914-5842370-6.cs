    public int MyProperty
    {
        get { return _myProperty; }
        set
        {
            _myProperty = value;
            if (_myProperty == 1)
            {
                // DO SOMETHING HERE
            }
        }
    }
    private int _myProperty;
