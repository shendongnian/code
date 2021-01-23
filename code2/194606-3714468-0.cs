    private static void RegisterContainer(IUnityContainer container)
    {            
        container
            .RegisterType<IUserService, UserService>()
            .RegisterType<IFacebookService, FacebookService>();
    }
IUserRepository is not registered.  Add a line like
    .RegisterType<IUserRepository, UserRepository>()
