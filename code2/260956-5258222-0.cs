    private int? foo;
    public int Foo {
        get { return foo.GetValueOrDefault(); }
        set { foo = value; }
    }
    public bool ShouldSerializeFoo() { return foo.HasValue;}
