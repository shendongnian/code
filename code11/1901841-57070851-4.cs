    ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            client.ClientCredentials.Windows.ClientCredential.UserName = "Administrator";
            client.ClientCredentials.Windows.ClientCredential.Password = "abcd1234!";
            try
            {
                var result = client.Test();
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                throw;
            }
