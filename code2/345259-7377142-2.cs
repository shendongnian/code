    public static void initialize()
    {
        using (ServiceHost host = new ServiceHost(typeof(MBClientConsole),
          new Uri[]{new Uri("net.pipe://localhost")}))
        {
            host.AddServiceEndpoint(typeof(IMBClientConsole),
              new NetNamedPipeBinding(),
              "PipeReverse");
    
            host.Open();
            // TODO: host.Close();
        }
    }
