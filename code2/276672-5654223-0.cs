    string Property1 
    { 
        get { return _Property1; }
        set
        {
            if (String.IsNullOrEmpty(value)) return;
            _Property1 = value
        }
    }
    private string _Property1;
