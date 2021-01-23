    [Browsable(true)]
    public bool GreatBrowsableProperty { get; set; }
    
    [Browsable(false)]
    public bool NonBrowsableProperty { get; set; }
    
    [MyOwnBrowsable]
    public bool BrowsablePropertyMyOwn { get; set; }
