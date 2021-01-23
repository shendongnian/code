    Configuration config;
    
    bool isWebApp = HttpRuntime.AppDomainAppId != null;
    
    if (isWebApp)
    {
        config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
    }
    else
    {
        config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }
    
    var mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;    
                        
