    public object Property1 {get; set;}
    public object Property2 {get; set;}
    public bool Property3
    {
        get { return Property1 != null && Property2 != null; }
    }
