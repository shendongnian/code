    public bool NotChanging { get; private set; };
    private bool _someBool;
    public bool SomeBool
    {
        get { return _someBool; }
        set {
            NotChanging  = value == _someBool;
            _someBool = value;
        }
    }
