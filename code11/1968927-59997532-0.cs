       Uri uri = new Uri("http://localhost:8004");
                WebHttpBinding binding = new WebHttpBinding();
                binding.Security.Mode = WebHttpSecurityMode.None;
    
                using (ServiceHost sh = new ServiceHost(typeof(MyService), uri))
                {
                    ServiceEndpoint se=sh.AddServiceEndpoint(typeof(IService), binding,"");
                    se.EndpointBehaviors.Add(new WebHttpBehavior());
    
                    sh.Opened += delegate
                    {
                        Console.WriteLine("Service is ready");
                    };
                    sh.Closed += delegate
                    {
                        Console.WriteLine("Service is clsoed");
                    };
        sh.Open();
                    Console.ReadLine();
                    //pause
                    sh.Close();
                    Console.ReadLine();
