    using System.Configuration;
    using System.Web.Configuration;
    
    Configuration cfg = WebConfigurationManager.OpenWebConfiguration("/");
    HttpHandlersSection hdlrs = (HttpHandlersSection)cfg.GetSection("system.web/httpHandlers");
