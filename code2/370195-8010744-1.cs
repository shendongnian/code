    public int Foo {get;set;}
    [XmlIgnore]
    public bool FooSpecified {
        get { return false; } // never serialize
        set { }
    }
