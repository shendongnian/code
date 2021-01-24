    public class YourAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Also register any custom type converter/value resolvers
            builder.RegisterType<CustomValueResolver>().AsSelf();
            builder.RegisterType<CustomTypeConverter>().AsSelf();
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyModel MyDto>;
                //etc...
            })).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
