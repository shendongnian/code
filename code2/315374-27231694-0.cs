    string _Title;
    public string Title
    {
        get
        {
            if (_Title == null)
            {   
                _Title = getTitle().GetAwaiter().GetResult();
            }
            return _Title;
        }
        set
        {
            if (value != _Title)
            {
                _Title = value;
                RaisePropertyChanged("Title");
            }
        }
    }
