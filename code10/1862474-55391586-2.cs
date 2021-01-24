     using (ServiceHost host = new ServiceHost(typeof(Service.EmployeeService)))
            {
                host.Description.Endpoints[0].EndpointBehaviors.Add(new ReplaceActionFilterEndpointBehavior());
                host.Opened += delegate
                {
                    Console.WriteLine("hello");
                };
                host.Open();
                  Console.Read();
            }
