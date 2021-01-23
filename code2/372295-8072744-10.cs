     List<ServiceHost> serviceHosts = new List<ServiceHost>();
    
         foreach(type t in mappings.Keys)
        {
                string url = string.Format("net.tcp://{0}:{1}/YouNameSpace_{2}.svc","YourHost","YourPort",t.name);
          ServiceHost serviceHost = new ServiceHost(mappings[t] , new Uri(url));
        
                  serviceHost.Open();
        
                  mServiceHosts.Add(serviceHost);
        }
