                    Console.WriteLine("Opening host...");
                host.Open();
                foreach (ServiceEndpoint endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine("Endpoint:");
                    Console.WriteLine("   Address: {0}", endpoint.Address.Uri);
                    Console.WriteLine("   Binding: {0}", endpoint.Binding);
                    Console.WriteLine("   Contract: {0}", endpoint.Contract.Name);
                }
                Console.WriteLine("Waiting...");
