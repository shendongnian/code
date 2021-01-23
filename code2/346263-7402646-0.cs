     public ServiceHost CreateService(Uri baseAddress)
            {
                // create the net.tcp binding for the service endpoint
                NetTcpBinding ntcBinding = new NetTcpBinding();
                ntcBinding.Security.Mode = SecurityMode.None;
                System.ServiceModel.Channels.Binding tcpBinding = ntcBinding;
    
                // create the service host and add the endpoint
                ServiceHost host = new ServiceHost(typeof(RMS.Gateway.Services.RiskLinkService), baseAddress);
    
                host.Opening += new EventHandler(host_Opening);
                host.Opened += new EventHandler(host_Opened);
                host.Closing += new EventHandler(host_Closing);
                host.Closed += new EventHandler(host_Closed);
                host.Faulted += new EventHandler(host_Faulted);
                host.UnknownMessageReceived += new EventHandler<UnknownMessageReceivedEventArgs>(host_UnknownMessageReceived);
    
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    
                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();
    
                //smb.HttpGetEnabled = true;
    
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    
                host.Description.Behaviors.Add(smb);
    
                // Add MEX endpoint
                host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexTcpBinding(),
                  "mex"
                );
    
                host.AddServiceEndpoint(typeof(RAE.Entities.ServiceInterfaces.IRiskLinkService), ntcBinding, string.Empty);
    
                host.Open();
    
                return host;
            }
