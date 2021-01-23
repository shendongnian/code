    private string myVar;
    public string MyProperty
    {
        [DebuggerStepThrough]
        get { return myVar; }
        [DebuggerStepThrough]
        set
        {
            if (value != myVar)
            {
                myVar = value;
                OnPropertyChanged("MyProperty");
            }
        }
    }
