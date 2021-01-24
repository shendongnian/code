    var client = new ServiceReference1.ServiceClient();
                client.ClientCredentials.UserName.UserName = "jack";
                client.ClientCredentials.UserName.Password = "123456";
                try
                {
                    var result = client.SayHello();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
