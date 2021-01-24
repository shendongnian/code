    Uri mexuri = new Uri("http://localhost:1500");
                Uri serviceuri = new Uri("net.pipe://localhost/mypipe");
                NetNamedPipeBinding binding = new NetNamedPipeBinding();
                binding.Security.Mode = NetNamedPipeSecurityMode.None;
                //WSDualHttpBinding binding = new WSDualHttpBinding();
                //binding.Security.Mode = WSDualHttpSecurityMode.None;
                using (ServiceHost sh = new ServiceHost(typeof(Calculator), mexuri))
                {
                sh.AddServiceEndpoint(typeof(ICalculator), binding,serviceuri);
                ServiceMetadataBehavior smb;
                smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    sh.Description.Behaviors.Add(smb);
                }
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "MEX");
    
                sh.Open();
                Console.Write("Service is ready....");
                Console.ReadLine();
                sh.Close();
                }
