    private string _Name;
    public string Name
    {
        get { return _Name; }
        set
        {
            if (_Name != value) {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
