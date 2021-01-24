    private string _linkAddress;
    public string LinkAddress
    {
        get { return _linkAddress; }
        set { _linkAddress = value; PropertyChanged(this, new PropertyChangedEventArgs(nameof(LinkAddress))); }
    }
