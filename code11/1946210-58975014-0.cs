    protected override Assembly[] GetViewAssemblies()
    {
        var list = new List<Assembly>(base.GetViewAssemblies());
        list.Add(typeof(SomeTypeFromAdditionalViewAssembly).Assembly);
        return list;
    }
