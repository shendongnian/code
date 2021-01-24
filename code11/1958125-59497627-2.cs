    ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
    //apply the endpoint behavior.
                client.Endpoint.Behaviors.Add(new AuthBehavior());
                var result = client.SayHello();
                Console.WriteLine(result);
