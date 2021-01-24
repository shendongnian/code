    public void ConfigureContainer(ContainerBuilder builder)
    {
        //builder.RegisterType<EpisodeServices>().As<IEpisodeService>().InstancePerLifetimeScope(); This works
        var executingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //The sth is my Solution's header for example Sth.Core, Sth.Models, Sth.Services all are childs to the Sth Solution
        string[] files = Directory.GetFiles(executingDirectory, "Sth.*.dll", SearchOption.AllDirectories);
        var listOfAssemblies = new List<Assembly>();
        foreach (var file in files)
            listOfAssemblies.Add(Assembly.LoadFile(file));
        builder
            .RegisterAssemblyTypes(listOfAssemblies.ToArray())
            .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(ISthScopedService))))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
