    public void CreateRepository(string name)
    {
        var type = Type.GetType(name);
        var genericRepositoryType = typeof(Repository<>).MakeGenericType(type);
        var repositoryObj = Activator.CreateInstance(genericRepositoryType );
        // N.B. repositoryObj is System.Object
    }
