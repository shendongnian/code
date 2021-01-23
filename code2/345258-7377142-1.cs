    class Log
    {
    
        ServiceHost _host;
        public void Initialize()
        {
          _host = new ServiceHost(typeof(MBClientConsole),
              new Uri[]{new Uri("net.pipe://localhost")}))
            {
                _host.AddServiceEndpoint(typeof(MBClientConsole),
                  new NetNamedPipeBinding(),
                  "PipeReverse");
    
                _host.Open();
            }
        }
        
        public void Close()
        {
           _host.Close();
           _host.Dispose();
        }
    }
