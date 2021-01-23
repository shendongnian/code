    public Test()
    {
        var data = Enumerable.Range(1, 5).Select(i => new
        {
            Id = i,
            Foo = "Foo",
            Bar = 2
        }.AsDynamicDictionary());
    }
    
