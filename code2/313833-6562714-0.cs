    // base type 
    protected string Foo {get;set;}
    // derived type
    new public string Foo {
        get { return base.Foo; }
        protected set { base.Foo = value; }
    }
