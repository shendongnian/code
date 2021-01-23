    var service = this.GetService(typeof(System.Web.UI.Design.IWebApplication)) as IWebApplication;
    if (service != null)
    {
        var configuration = service.OpenWebConfiguration(false);
        if (configuration != null)
        {
            var section = configuration.GetSection("system.web/httpHandlers") as HttpHandlersSection;
            if (section != null)
            {
                var httpHandlerAction = new HttpHandlerAction("MyAwesomeHandler.axd", typeof(MyAwesomeHandler).AssemblyQualifiedName, "GET,HEAD", false);
                section.Handlers.Add(httpHandlerAction);                
                configuration.Save();
            }
            else 
            {
                // no system.web/httpHandlers section found... deal with it
            }
        }
        else 
        {
            // no web config found... 
        }
    }
    else 
    {
        // Couldn't get IWebApplication service
    }
