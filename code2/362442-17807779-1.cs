    //Property of class foo
    private string _address_Notes;
    public string Address_Notes 
    { 
        get { return _address_Notes ?? string.Empty; } 
        set { _address_Notes = value; }
    }
