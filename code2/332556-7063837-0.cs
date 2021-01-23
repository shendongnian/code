    string _timeZone;
    public string TimeZone
    {
        get
        {
            if (_timeZone== null)
                return "";
    
            return _timeZone;
        }
        set { _timeZone= value; }
    }
