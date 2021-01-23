    public bool Solved // This is slow!
    {
        get
        {
            return _solved;
        }
        set
        {
            _solved = value;
            mreStop.Set();
        }
    }
