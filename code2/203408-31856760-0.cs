    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;
        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "MyWCFServer";
            service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);
            service.Committed += new InstallEventHandler(serviceInstaller_Committed);
        }
        void serviceInstaller_Committed(object sender, InstallEventArgs e)
        {
            ServiceController controller = new ServiceController(service.ServiceName);
            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running);
        }
    }
