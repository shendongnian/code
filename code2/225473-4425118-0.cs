    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (_name != value)
            {
                _name = value;
                RaisePropertyChanged("Name");  // assuming this method handles raising the event
            }
        }
    }
