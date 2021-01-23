    //0
    public override void Run(bool runWithDefaultConfiguration)
    {
        base.Run(runWithDefaultConfiguration);
        //this is our last opportunity to hook into the PRISM bootstrapping sequence; at this point every very other base-overridden 
        //method has been executed
    }
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
    }
