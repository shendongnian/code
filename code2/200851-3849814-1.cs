    public void CreateRepository(string name)
    {
        var type = Type.GetType(name);
        var genericRepositoryType = typeof(Repository<>).MakeGenericType(type);
        var repositoryObj = Activator.CreateInstance(genericRepositoryType );
        // N.B. repositoryObj variable is System.Object
        //      but is also an istance of Repository<name>
    }
