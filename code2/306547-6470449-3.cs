    var container = new Container(x =>
    {
        x.Scan(scan =>
        {
            scan.TheCallingAssembly();
            scan.WithDefaultConventions();
            scan.ConnectImplementationsToTypesClosing(typeof(IProcessor<>));
        });
    
        x.For<IProcessor>().Use(context =>
        {
            // Get the settings object somehow - I'll assume an ISettingsSource
            var settings = context.GetInstance<ISettingsSource>().GetSettings();
            // Need access to full container, since context interface does not expose ForObject
            var me = context.GetInstance<IContainer>();
            // Get the correct IProcessor based on the settings object
            return me.ForObject(settings).
                GetClosedTypeOf(typeof (IProcessor<>)).
                As<IProcessor>();
        });
    });
