    Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");
                ServiceHost selfHost = new ServiceHost(typeof(WcfServiceLibrary1.Service1), baseAddress);
                try
                {
                    selfHost.AddServiceEndpoint(typeof(WcfServiceLibrary1.IService1), new WSHttpBinding(), "CalculatorService");
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb);
