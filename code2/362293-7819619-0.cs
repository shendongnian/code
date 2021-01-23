    var web=System.Web.Configuration.WebConfigurationManager
              .OpenWebConfiguration("~/admin/web.config");
    
    String appValue=web.AppSettings.Settings["key"].Value;
        
