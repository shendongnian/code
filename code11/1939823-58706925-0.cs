    private string _a;
    public string A
    {
        get { return _a; }
        set { SetA(value, true); }
    }
    
    protected void SetA(string value, bool isUserInput)
    {
        _a = value;
        if (isUserInput)
        {
            // aditional operations
        }
        OnPropertyChanged("A");
    }
