    public ServiceInstaller()
    {
        InitializeComponent();
        this.Committed += new InstallEventHandler(ProjectInstaller_Committed);
    }
    
    void ProjectInstaller_Committed(object sender, InstallEventArgs e)
    {
        ServiceController sc = new ServiceController(serviceInstaller1.ServiceName);
        sc.Start();
    }
