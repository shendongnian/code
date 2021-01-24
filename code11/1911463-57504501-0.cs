       ServiceReference1.ServiceClient client = new ServiceClient();
                try
                {
                    var result = client.GetData();
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
    
                    throw;
                }
