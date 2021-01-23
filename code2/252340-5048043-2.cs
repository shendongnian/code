    private string _displayName = string.Empty;
    public string DisplayName
    {
        get { return _displayName; }
        set 
        { 
            if (_displayName != value)
            {
                _displayName = value; 
                NotifyPropertyChanged("DisplayName");
            }
        }
    }
