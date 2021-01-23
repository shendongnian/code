     protected void Application_Start()
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
                RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
            }
    public static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection filters)
            {
                filters.Add(new CredentialsActionFilter());
            }
