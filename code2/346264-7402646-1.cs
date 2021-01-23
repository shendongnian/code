    Uri baseAddress = new Uri(ConfigurationManager.AppSettings["serviceURL"]);
            // Create the ServiceHost.
            using (ServiceHost host = serviceFactory.CreateService(baseAddress))
            {
                System.Console.WriteLine("The service is ready at {0}", baseAddress);
                System.Console.WriteLine("Press <Enter> to stop the service.");
                System.Console.ReadLine();
                // Close the ServiceHost.
                host.Close();
            }
