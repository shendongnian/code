    void WSFederationAuthenticationModule_SecurityTokenValidated(object sender, SecurityTokenValidatedEventArgs e)
    {
    	FederatedAuthentication.SessionAuthenticationModule.IsReferenceMode = true;
    }
    // or
    void WSFederationAuthenticationModule_SessionSecurityTokenCreated(object sender, SessionSecurityTokenCreatedEventArgs e)
    {
    	e.SessionToken.IsReferenceMode = true;
    }
