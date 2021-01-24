    private bool _isAddAppledEnabled = false;
    public bool IsAddAppledEnabled
    {
      get { return _isAddAppledEnabled; }
      set
      {
        if (_isAddAppledEnabled == value)
          return;
        _isAddAppledEnabled = value;
        IsAddOrangeEnabled = !value;
        OnPropertyChanged(nameof(IsAddAppledEnabled));
      }
    }
    private bool _isAddOrangeEnabled = false;
    public bool IsAddOrangeEnabled
    {
      get { return _isAddOrangeEnabled; }
      set
      {
        if (_isAddOrangeEnabled == value)
          return;
        _isAddOrangeEnabled = value;
        IsAddAppledEnabled = !value;
        OnPropertyChanged(nameof(IsAddOrangeEnabled));
      }
    }
