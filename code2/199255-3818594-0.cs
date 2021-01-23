    // implement the interface
    public event PropertyChangedEventHandler PropertyChanged;
    // use this for every property
    private long _Total;
    public long Total {
        get {
            return _Total;
        }
        set {
            _Total = value;
            if(PropertyChanged != null) {
                // notifies wpf about the property change
                PropertyChanged(this, new PropertyChangedEventArgs("Total"));
            }
        }
    }
