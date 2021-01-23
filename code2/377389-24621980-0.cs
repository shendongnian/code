<span>Try including the getter:</span>
    private OverviewViewModel _vm;
    [Dependency]
    public OverviewViewModel VM
    {
        set
        {
            _vm = value;
            this.DataContext = _vm;
        }
        get
        {
            return _vm;
        }
    }
