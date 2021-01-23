    this.Scan(x =>
    {
        x.AssemblyContainingType<HomeController>();
        x.AddAllTypesOf<IController>();
        x.Include(t => typeof(IController).IsAssignableFrom(t));
    });
