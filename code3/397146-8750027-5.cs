    public bool Solved
    {
        get
        {
            return _solved;
        }
    }
    // As Eric suggests, this should be a private method, not a property set.
    private void SetCompleted()
    {
        _solved = value;
        mreStop.Set();
    }
