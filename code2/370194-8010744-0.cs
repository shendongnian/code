    [DataMember]
    public int Foo {get;set;}
    public bool FooSpecified {
        get { return false; } // never serialize
        set { }
    }
