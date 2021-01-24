    private static void RegisterDependencies()
    {
        var builder = new ContainerBuilder();
    
        builder.DefaultControlledBy<HttpRequestLifecycle>();
    
        SessionFacade.DatabaseSessionFactories[DbConnectionSessionType.MsqlSession] = NHConfiguration.CreateSessionFactory();
        SessionFacade.DatabaseSessionFactories[DbConnectionSessionType.PostgresqlSession] = NHConfiguration.CreatePostgresSessionFactory();
    
        builder.Register(c => c.ResolveAll<IDatabaseSessions>()).ControlledBy<HttpRequestLifecycle>();
    
        LightCoreConfiguration.RegisterGlobalDependencies(builder);
        
        // Build the container.
        _container = builder.Build();
    }
    protected void Application_EndRequest(object sender, EventArgs e)
    {
                var sessions = _container.Resolve<IDatabaseSessions>();
    
                sessions.MssqlSession.Close();
                sessions.MssqlSession.Dispose();
    
                sessions.PostgresqlSession.Close();
                sessions.PostgresqlSession.Dispose();
    }
