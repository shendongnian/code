    string _name = "";
    public string Name
    {
        get { return FriendlyName ?? _name; }
        set { _name = value; }
    }
