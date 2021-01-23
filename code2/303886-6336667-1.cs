    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        FederatedAuthentication.ServiceConfigurationCreated += new EventHandler<Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs>(FederatedAuthentication_ServiceConfigurationCreated);   
    }
        void FederatedAuthentication_ServiceConfigurationCreated(object sender, Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs e)
        {
            var m = FederatedAuthentication.WSFederationAuthenticationModule;
            m.RedirectingToIdentityProvider += new EventHandler<RedirectingToIdentityProviderEventArgs>(m_RedirectingToIdentityProvider);
        }
        void m_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            var sim = e.SignInRequestMessage;
            sim.HomeRealm = "Google";
        }
