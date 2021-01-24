     builder.RegisterType<ResultConverter>().AsSelf();
     builder.Register(context => new MapperConfiguration(options=>
     {
         options.CreateMap<Contract.Dto.Result, List<Result>>(MemberList.Source).ConvertUsing<ResultConverter>();
         options.CreateMap<Contract.Dto.Result, Result>(MemberList.Source);
     })).AsSelf().SingleInstance();
     builder.Register(c =>
     {
         //This resolves a new context that can be used later.
         var context = c.Resolve<IComponentContext>();
         var config = context.Resolve<MapperConfiguration>();
         return config.CreateMapper(context.Resolve);
     }).As<IMapper>().InstancePerLifetimeScope();
