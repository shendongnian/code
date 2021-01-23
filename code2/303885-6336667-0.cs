    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        FederatedAuthentication.ServiceConfigurationCreated += new EventHandler<Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs>(FederatedAuthentication_ServiceConfigurationCreated);   
    }
        void m_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
        {
            var sim = e.SignInRequestMessage;
            sim.HomeRealm = "Google";
        }
