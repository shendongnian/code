    ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            //client.Endpoint.EndpointBehaviors.Add(new AuthBehavior());
            try
            {
                Console.WriteLine(client.SayHello());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
