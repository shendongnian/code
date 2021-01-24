    //it will use the binding and service endpoint address in the system.servicemode section.
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
                    //windows account on the server.
                    client.ClientCredentials.Windows.ClientCredential.UserName = "administrator";
                    client.ClientCredentials.Windows.ClientCredential.Password = "abcd1234!";
                    try
                    {
                        Console.WriteLine(client.SayHello());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
