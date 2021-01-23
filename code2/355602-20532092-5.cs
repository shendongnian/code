    kernel.Bind<IDataRepository>()
          .To<EFDataRepository>()
          .InRequestScope();
    
    kernel.Bind<MyDbContext>().ToSelf()
          .InRequestScope()
          .WithConstructorArgument("context", ninjectContext=>HttpContext.Current);
