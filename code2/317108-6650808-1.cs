     try
            {
                var host2 = CreateServiceHost("localhost:5432", serviceImpl);
                Console.WriteLine("#2, config: " + host2.BaseAddresses.First().ToString());
                host2.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
