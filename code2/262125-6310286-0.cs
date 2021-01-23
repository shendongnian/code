    private string _description = string.Empty;
    [StringLength(100, ErrorMessage = "Description Max Length is 100")]
    public string Description 
    {  
        get { return _description; }
        set { _description = value.Substring(0,100); };  // or something equivalent
    } 
