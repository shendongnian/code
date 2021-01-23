    using System.Configuration.Install;
    using System.ServiceProcess;
    using System.ComponentModel;
    
    
    namespace SAS
    {
        [RunInstaller(true)]
        public class MyProjectInstaller : Installer
        {
            private ServiceInstaller serviceInstaller1;
            private ServiceProcessInstaller processInstaller;
    
            public MyProjectInstaller()
            {
                // Instantiate installer for process and service.
                processInstaller = new ServiceProcessInstaller();
                serviceInstaller1 = new ServiceInstaller();
    
                // The service runs under the system account.
                processInstaller.Account = ServiceAccount.LocalSystem;
    
                // The service is started manually.
                serviceInstaller1.StartType = ServiceStartMode.Manual;
    
                // ServiceName must equal those on ServiceBase derived classes.
                serviceInstaller1.ServiceName = "SAS Service";
    
                // Add installer to collection. Order is not important if more than one service.
                Installers.Add(serviceInstaller1);
                Installers.Add(processInstaller);
            }
        }
    }
