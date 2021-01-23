    private int _length1 = 0;
    public int Length1
    {
        get { return _length1; }
        set
        {
            if (_length1 == value) return;
            _length1 = value;
            OnPropertyChanged("Length1");
            OnPropertyChanged("Result1");
            OnPropertyChanged("Result2");
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }	
