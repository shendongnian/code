            ServiceHost host = new ServiceHost(typeof(SelfHostedService.Service));
            // enumerate over each <service> node
            foreach (ServiceElement aService in services.Services)
            {
                Console.WriteLine();
                Console.WriteLine("Name: {0} / Behavior: {1}", aService.Name, aService.BehaviorConfiguration);
                // enumerate over all endpoints for that service
                foreach (ServiceEndpointElement see in aService.Endpoints)
                {
                    Console.WriteLine("\tEndpoint: Address = {0} / Binding = {1} / Contract = {2}", see.Address, see.Binding, see.Contract);
                    //host.AddServiceEndpoint(
                }
            }
