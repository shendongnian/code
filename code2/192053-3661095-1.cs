    get
    {
         _oRootConfig = (System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath));
         return _oRootConfig;
    }
    
    set
    {
         _oRootConfig = value;
    }
