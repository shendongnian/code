    protected override Assembly[] GetViewModelAssemblies()
    {
        var list = new List<Assembly>(base.GetViewModelAssemblies());
        list.Add(typeof(SomeTypeFromAdditionalViewModelAssembly).Assembly);
        return list;
    }
