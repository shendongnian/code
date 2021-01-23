    Application_BeginRequest(...)
    {
      var childContainer = _container.CreateChildContainer();
      HttpContext.Items["container"] = childContainer;
      childContainer.RegisterType<ObjectContext, MyContext>
         (new ContainerControlledLifetimeManager());
    }
    
    Application_EndRequest(...)
    {
      var container = HttpContext.Items["container"] as IUnityContainer
      if(container != null)
        container.Dispose();
    }
