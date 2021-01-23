    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        [RunInstaller(true)]
        public class MyWindowsServiceInstaller : Installer
        {
            public MyWindowsServiceInstaller()
            {
                var processInstaller = new ServiceProcessInstaller();
                var serviceInstaller = new ServiceInstaller();
    
                //set the privileges
                processInstaller.Account = ServiceAccount.LocalSystem;
    
                serviceInstaller.DisplayName = "My Service";
                serviceInstaller.StartType = ServiceStartMode.Automatic;
    
                //must be the same as what was set in Program's constructor
                serviceInstaller.ServiceName = "My Service";
                this.Installers.Add(processInstaller);
                this.Installers.Add(serviceInstaller);
            }
        }
    }
