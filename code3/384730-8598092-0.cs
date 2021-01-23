    public Test()
    {
        var data = Enumerable.Range(1, 5).Select(i => new
        {
            Id = i,
            Foo = "Foo",
            Bar = 2
        });
        var result = data
            .Select(d => d.GetType().GetProperties()
                .Select(p => new { Name = p.Name, Value = p.GetValue(pd, null) })
                .ToDictionary(
                    pair => pair.Name,
                    pair => pair.Value == null ? string.Empty : pair.Value.ToString()));
    }
