    void Application_Start(object sender, EventArgs e)
    {
    	// Called only once on application start
    	// This is not the right place to wire events for all HttpApplication instances
    }
    
    public override void Init()
    {
    	// Called for each HttpApplication instance
    	FederatedAuthentication.WSFederationAuthenticationModule.SecurityTokenValidated += STV;
    	FederatedAuthentication.WSFederationAuthenticationModule.SessionSecurityTokenCreated += SSTC;
    }
    
    void STV(object sender, SecurityTokenValidatedEventArgs e)
    {
    	FederatedAuthentication.SessionAuthenticationModule.IsReferenceMode = true;
    }
    // or
    
    void SSTC(object sender, SessionSecurityTokenCreatedEventArgs e)
    {
    	e.SessionToken.IsReferenceMode = true;
    }
