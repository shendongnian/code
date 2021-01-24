    private bool _isAddAppledEnabled;
    public bool IsAddAppledEnabled
    {
        get { return _isAddAppledEnabled; }
        set
        {
            _isAddAppledEnabled= value;
            _isAddOrangeEnabled= !value;
            OnPropertyChanged(nameof(IsAddAppledEnabled));
	    OnPropertyChanged(nameof(IsAddOrangeEnabled));
        }
    }
    private bool _isAddOrangeEnabled;
    public bool IsAddOrangeEnabled
    {
        get { return _isAddOrangeEnabled; }
        set
        {
            _isAddOrangeEnabled= value;
            _isAddAppledEnabled= !value;
            OnPropertyChanged(nameof(IsAddOrangeEnabled));
	    OnPropertyChanged(nameof(IsAddAppledEnabled));
        }
    }
