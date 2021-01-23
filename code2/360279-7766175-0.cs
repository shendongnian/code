    public int X
    {
        get { return _x; }
        set
        {
            if (!(value >= -10 && value <= 10))
                throw new Exception("Some error text");
            _x = value;
        }
    }
