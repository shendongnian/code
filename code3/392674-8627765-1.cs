    private double _length1;
    public double Length1
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
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }	
