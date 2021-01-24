    System.Reflection.Assembly[] assemblies = new[] { System.Reflection.Assembly.GetExecutingAssembly() };
    IEnumerable<Type> scriptTypes = assemblies
    	.SelectMany(a => a.GetTypes())
    	.Where(t => t != typeof(BaseScript) && typeof(BaseScript).IsAssignableFrom(t) && !t.IsAbstract);
    
    ServiceCollection serviceCollection = new ServiceCollection();
    foreach (Type scriptType in scriptTypes)
    	serviceCollection.AddTransient(typeof(BaseScript), scriptType);
    
    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
