    public event PropertyChangedEventHandler PropertyChanged;
    private int _foo;
    public int Foo
    {
        get { return _foo; }
        set
        {
            if (_foo != value)
            {
                _foo = value;
                NotifyPropertyChanged("Foo");
            }
        }
    }
    private void NotifyPropertyChanged(string info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
