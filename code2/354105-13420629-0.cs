    protected override void InitializeShell()
    {
       Application.Current.MainWindow = (Window)Container.Resolve<ShellView>();
    }
    protected override void InitializeModules()
    {
       base.InitializeModules();
       Application.Current.MainWindow.Show();
    }
