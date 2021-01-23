    Scan(x =>
    {
        x.WithDefaultConventions();
        x.AssemblyContainingType(typeof(TeamEmployeeRepository));
        x.AddAllTypesOf(typeof(Repository<>));
        x.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
    });
