    private string _Name = string.Empty;
    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value ?? string.Empty;
        }
    }
