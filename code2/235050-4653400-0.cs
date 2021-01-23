    private void Application_Start() {
      _parentContainer = new UnityContainer();
       //creates a transient registration, available at any point in the app.
      _parentContainer.RegisterType<IParentIntf, ParentIntfImpl>();
      ControllerBuilder.Current.SetControllerFactory(new ServiceLocatorControllerFactory());
    }
    
    private void Application_BeginRequest() {
      var childContainer = _parentContainer.CreateChildContainer();
      //registers a request "singleton"
      //This registration is a type registration, an instance of RequestInterfaceImpl
      //will be created when needed and then kept in the container for later use.
      childContainer.RegisterType<IRequestInterface,RequestInterfaceImpl>(new ContainerControlledLifetimeManager());
      //save the child container in the context, so we can use it later
      HttpContext.Items["childContainer"] = childContainer;
    }
    
    private void Application_EndRequest() {
      //dispose the child container
      ((IUnityContainer)HttpContext.Items["childContainer"]).Dispose();
    }
