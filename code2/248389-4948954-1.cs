    // this style is introduced, which is more common, and suppose to be best
    public string Name { get; set; }
    
    //You can more customize it
    public string Name
    {
        get;
        private set;    // means value could be set internally, and accessed through out
    }
