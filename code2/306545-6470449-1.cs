    var container = new Container(x =>
    {
        x.Scan(scan =>
        {
            scan.TheCallingAssembly();
            scan.WithDefaultConventions();
            scan.ConnectImplementationsToTypesClosing(typeof(IProcessor<>));
        });
    
        x.For<IProcessorConsumer>().Use(context =>
        {
            // Get the settings object somehow - I'll assume an ISettingsSource
            object settings = context.GetInstance<ISettingsSource>().GetSettings();
            // Need access to full container, since context does not expose the ForObject method
            var me = context.GetInstance<IContainer>();
            // Get the correct IProcessor based on the settings object
            var processor = me.ForObject(settings).
                GetClosedTypeOf(typeof(IProcessor<>)).
                As<IProcessor>();
            // Use the retrieved IProcessor when building ProcessConsumer
            return me.With(processor).GetInstance<ProcessorConsumer>();
        });
    });
