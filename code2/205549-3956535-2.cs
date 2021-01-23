    using System.ComponentModel;
    using System.Configuration.Install;
    using System.ServiceProcess;
    
    namespace WindowsService1
    {
      [RunInstaller(true)]
      public class ProjectInstaller : Installer
      {
        private ServiceProcessInstaller serviceProcessInstaller1;
        private ServiceInstaller serviceInstaller1;
    
        public ProjectInstaller()
        {
          this.serviceProcessInstaller1 = new ServiceProcessInstaller();
          this.serviceInstaller1 = new ServiceInstaller();
    
          this.serviceProcessInstaller1.Password = null;
          this.serviceProcessInstaller1.Username = null;
    
          this.serviceInstaller1.ServiceName = "Service1";
    
          this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});
        }
      }
    }
