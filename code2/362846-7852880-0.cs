    private string _address = string.Empty; // IMPORTANT!
    
    [StringLengthValidator(30, "Max. 30 chars")]
    public string Address {
        get { return _address; }
        set { _address = value; }
    }
