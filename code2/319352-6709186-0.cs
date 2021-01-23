    public string MyStringProperty { get; set; }
    
    [NotMapped]
    public bool MyBoolProperty
    { 
        get { return MyStringProperty == "T"; }
        set { MyStringProperty = value ? "T" : "F"; }
    }
