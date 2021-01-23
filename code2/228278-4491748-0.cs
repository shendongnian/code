      //Register instance at some starting point in your application
      container.RegisterInstance<IActiveSessionService>(new ActiveSessionService());
      //This single instance can then be resolved by clients directly, but usually it
      //will be automatically resolved as a dependency when you resolve other types. 
      IActiveSessionService session = container.Resolve<IActiveSessionService>();
