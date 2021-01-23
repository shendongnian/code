    public bool MyProp
    {
        get;
        private set;
    }
    
    public int MyProp_AsInt
    {
        set
        {
            MyProp = (value > 0) ? true : false;
        }
    }
