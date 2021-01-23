    private bool _Enabled;
    public bool Modified { get; set; }
    public bool Enabled
    {
        get 
        {
            return _Enabled;
        }
        set 
        {
            _Enabled = value; 
            Modified = true;
        }
    }
