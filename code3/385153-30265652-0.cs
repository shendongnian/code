    //1
    protected override void ConfigureModuleCatalog()
    {
        base.ConfigureModuleCatalog();
        ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        //add modules...
    }
    
    //2
    protected override void ConfigureContainer() 
    {
        base.ConfigureContainer();
        //register everything with the container...
    }
    
    //3
    protected override DependencyObject CreateShell()
    {
        return Container.Resolve<ShellView>();      //resolve your root component
    }
    
    //4
    protected override void InitializeShell()
    {
        base.InitializeShell();
        App.Current.MainWindow = (Window)Shell;
        App.Current.MainWindow.Show();
    }
    
    //5
    protected override void InitializeModules()
    {
        base.InitializeModules();
        //at this point, the object graph is fully built and all modules are finished loading. It's a good time to initiate any automatic runtime activities
        new MyBackgroundActivityStarter().KickOffApplicationActivities();
    }
