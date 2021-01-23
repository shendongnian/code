    Bind<IRepository>().To<Repository>();
    Bind<DbContext>().To<CentralStoreContext>()
        .When( context => context.Target != null 
            && context.Target.GetCustomAttributes( typeof( CentralStoreAttribute ) ) != null );
    // make the general binding after the more specific one
    Bind<DbContext>().To<UserStoreContext>();
