    Bind<IRepository>().ToMethod(x =>
    {
      var repositoryType = x.Kernel
                    .Get<IConfigObject>()
                    .SomeStringPropertyDenotingTheRepository;
      switch (repositoryType )
      {
        case "1": return (IRepository)new Repository1();
        default: return (IRepository)new Repository2();
      }
    }).InRequestScope();
