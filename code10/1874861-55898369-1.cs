    private bool _visibility;
    public bool Visibility
    {
        get => _visibility;
        set
        {
            _visibility = value;
            OnPropertyChanged("Visibility");
        }
    }
