    private string _myProp = string.Empty;
    public string MyProp
    {
        get
        {
            return _myProp;
        }
        set
        {
            if (value == null)
            {
                _myProp = string.Empty;
                return;
            }
     
            _myProp = value;
        }
    }
