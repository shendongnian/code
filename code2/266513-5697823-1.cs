    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace StackOverflow
    {
        [RunInstaller(true)]
        public partial class RtdServerInstaller : System.Configuration.Install.Installer
        {
            public RtdServerInstaller()
            {
                InitializeComponent();
            }
    
            [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
            public override void Commit(IDictionary savedState)
            {
                base.Commit(savedState);
    
                var registrationServices = new RegistrationServices();
                if (registrationServices.RegisterAssembly(GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase))
                    Trace.TraceInformation("Types registered successfully");
                else
                    Trace.TraceError("Unable to register types");
            }
    
            [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
            public override void Install(IDictionary stateSaver)
            {
                base.Install(stateSaver);
    
                var registrationServices = new RegistrationServices();
                if (registrationServices.RegisterAssembly(GetType().Assembly, AssemblyRegistrationFlags.SetCodeBase))
                    Trace.TraceInformation("Types registered successfully");
                else
                    Trace.TraceError("Unable to register types");
            }
    
            public override void Uninstall(IDictionary savedState)
            {
                var registrationServices = new RegistrationServices();
                if (registrationServices.UnregisterAssembly(GetType().Assembly))
                    Trace.TraceInformation("Types unregistered successfully");
                else
                    Trace.TraceError("Unable to unregister types");
    
                base.Uninstall(savedState);
            }
        }
    }
  
