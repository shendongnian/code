    protected void Application_Start()
    {
    		AreaRegistration.RegisterAllAreas();
    		RegisterRoutes(RouteTable.Routes);
    		SetupNHibernate();
    }
    
    public virtual void SetupNHibernate()
    {
    		NHibernateRepository.Current.Configure(RoadkillSettings.DatabaseType, Settings.ConnectionString, false, Settings.CachedEnabled);
    }
