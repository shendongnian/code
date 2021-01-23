    public SiteVariation(IHttpContextBaseWrapper context)
    {
    
    }
    var container = new UnityContainer();
    container.RegisterType<IHttpContextBaseWrapper ,HttpContextBaseWrapper>();
