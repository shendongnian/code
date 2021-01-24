    Uri uri = new Uri("http://localhost:9900");
                WebHttpBinding binding = new WebHttpBinding();
               ServiceHost sh=new ServiceHost(typeof(MyService),uri);
                ServiceEndpoint se = sh.AddServiceEndpoint(typeof(IService), binding, "");
                se.EndpointBehaviors.Add(new WebHttpBehavior());
                ServiceMetadataBehavior smb;
                smb = sh.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb==null)
                {
                    smb = new ServiceMetadataBehavior()
                    {
                        HttpGetEnabled = true
                    };
                    sh.Description.Behaviors.Add(smb);
                }
                //Add MEX service endpoint to make the call from the third party possible.
                Binding mexbinding = MetadataExchangeBindings.CreateMexHttpBinding();
                sh.AddServiceEndpoint(typeof(IMetadataExchange), mexbinding, "mex");
                sh.Open();
                Console.WriteLine("service is ready");
                Console.ReadLine();
                sh.Close();
