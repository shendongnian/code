    private string _name;
        
    public string Name 
    { 
        get 
        {
            if (null != FriendlyName)
                return FriendlyName;
            else
                return _name;
        }
        set
        {
            _name = value;
        }
    }
