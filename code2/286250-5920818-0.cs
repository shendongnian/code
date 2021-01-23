    public Guid Foo {get;set;}
    public string FooString {
        get { return Foo.ToString("N"); }
        set { Foo = new Guid(value); }
    }
