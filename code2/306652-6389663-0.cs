    public bool IsDataLoaded
    {
        get
        {
            return _IsDataLoaded;
        }
        set
        {
            _IsDataLoaded = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsDataLoaded"));
                PropertyChanged(this, new PropertyChangedEventArgs("EmptyMessage"));
            }
        }
    }
