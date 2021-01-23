    var service = this.GetService(typeof(System.Web.UI.Design.IWebApplication)) as IWebApplication;
    if (service != null)
    {
        var configuration = service.OpenWebConfiguration(false);
        if (configuration != null)
        {
            var section = configuration.GetSection("system.web/httpHandlers") as HttpHandlersSection;
            //...
