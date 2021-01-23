    container
    	.RegisterType<UserIdent>(new InjectionFactory(c =>
    	{
    		return HttpContext.Current.Session == null
    			? new UserIdent()
    			: HttpContext.Current.Session["UserIdent"] as UserIdent;
    	}));
    
    container
    	.RegisterType<IBackendWrapper, BackendWrapper>(
    		new InjectionProperty("UserIdent", new ResolvedParameter<UserIdent>())
    	);
