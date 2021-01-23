    private int _data;
    public int IMyImmutableData.Data
    {
        get
        {
            return this._data;
        }
    }
    
    public int IMyMutableData.Data
    {
        get
        {
            return this._data;
        }
        set
        {
            this._data = value;
        }
    }
