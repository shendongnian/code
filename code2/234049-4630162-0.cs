    private string _name;
    public string Hello {    
    {
        get
        {
            if(_name == null)
                _name = "Default Name";
    
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged("Hello");
        }
    }
