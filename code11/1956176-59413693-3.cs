    public void Create(Thing t)
    {
        var foo = new Foo(t.Name);
        foo.Prop = t.Something;
    
        if (t.HasValue)
            foo.Add(t.Value);
    }
