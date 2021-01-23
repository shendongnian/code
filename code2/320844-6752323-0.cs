    protected void Application_BeginRequest() {
        var childContainer = this.Container.CreateChildContainer();
        HttpContext.Current.Items["container"] = childContainer;
        this.ControllerFactory.RegisterTypes(childContainer);
    }
    protected void Application_EndRequest() {
        var container = HttpContext.Current.Items["container"] as IUnityContainer;
        if (container != null) {
            container.Dispose();
        }
    }
