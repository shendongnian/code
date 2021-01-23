    how about
    
        using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.ServiceModel;
    
    namespace Windows_Service
    {
      public partial class WCFWindowsService : ServiceBase
      {
        ServiceHost m_serviceHost;
    
        protected override void OnStart(string[] args)
        {
          m_serviceHost = new ServiceHost(typeof(FirstWcfService.Service));
          m_serviceHost.Open();
        }
    
        protected override void OnStop()
        {
          if (m_serviceHost != null)
          {
            m_serviceHost.Close();
          }
          m_serviceHost = null;
        }
      }
    }
