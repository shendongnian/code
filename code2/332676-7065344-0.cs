    private string _firstName;
    
    public string FirstName
    {
        get 
        {
            return _firstName;
        }
        set
        {
            if (_firstName != null) throw ...
            _firstName = value;
        }
    }
