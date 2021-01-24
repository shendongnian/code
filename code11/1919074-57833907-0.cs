    private IRepository GetRepositoryInstance(Type typeEntity)
    {
        Type[] args = typeEntity.GetGenericArguments();
        for ( int i = 0; i < args.Length; i++ ) args[i] = args[i].BaseType;
        var typeRepository = typeEntity.MakeGenericType(args);
        return repository = Activator.CreateInstance(typeRepository);
    }
