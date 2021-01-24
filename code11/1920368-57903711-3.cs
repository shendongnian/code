    ServiceReference1.ServiceClient client = new ServiceClient();
                client.ClientCredentials.UserName.UserName = "jack";
                client.ClientCredentials.UserName.Password = "123456";
                try
                {
                    var result = client.GetData();
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    throw;
                }
