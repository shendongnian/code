    public event PropertyChangedEventHandler PropertyChanged = delegate { };
    public string Output
    {
        get { return _output; }
        set 
        { 
            _output = value; 
            PropertyChanged(this, new PropertyChangedEventArgs("Output")); 
        }
    }
