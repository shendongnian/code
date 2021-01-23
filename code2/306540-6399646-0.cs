    var container = new Container(x =>
    {
        x.For<IProcessorConsumer>().Use<ProcessorConsumer>();
        x.For<IProcessor>().Use(context =>
        {
            var model = context.GetInstance<IContainer>().Model;
            if (model.PluginTypes.Any(t => typeof(FooSettings).Equals(t.PluginType)))
            {
                return context.GetInstance<FooProcessor>();
            }
            return context.GetInstance<BarProcessor>();
        });
    });
