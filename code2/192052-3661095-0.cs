    get 
    { 
    return  (System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath)); 
    }
    
    set { _oRootConfig = value; }
