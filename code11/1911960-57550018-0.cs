    services.AddMvc().AddControllersAsServices().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    var builder = new ContainerBuilder();
    builder.Populate(services);
    builder.RegisterType<Foobar>().UsingConstructor(typeof(string)).WithParameter("name", "Eric").Named<Foobar>("Eric").SingleInstance();
    builder.RegisterType<Foobar>().UsingConstructor(typeof(string)).WithParameter("name", "Fred").Keyed<Foobar>("Fred").SingleInstance();
    var controllers = typeof(Startup).Assembly.GetTypes().Where(t => t.BaseType == typeof(ControllerBase)).ToArray(); // for api controller
    //var controllers = typeof(Startup).Assembly.GetTypes().Where(t => t.BaseType == typeof(Controller)).ToArray(); // for mvc controller
    builder.RegisterTypes(controllers).WithAttributeFiltering();
    Container = builder.Build();
