    private object _currentViewModel;
    public object CurrentViewModel
    {
        get { return _currentViewModel; }
        set
        {
            if (value != _currentViewModel)
            {
                _currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
    }
