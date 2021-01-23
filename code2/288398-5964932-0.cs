    private ViewModelBase _currentContent;
    public ViewModelBase CurrentContent 
    {
        get {return _currentContent;}
        set
        {
            if (value != _currentContent)
            {
                _currentContent = value;
                OnPropertyChanged("CurrentContent");
            }
        }
    }
