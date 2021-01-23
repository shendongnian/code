    private SettableLazy<string> _backingLazy = new SettableLazy<string>(GetStringFromDatabase);
    public string LazyInitializeString
    {
        get
        {
            return _backingLazy;
        }
        set
        {
            _backingLazy = value;
        }
    }
