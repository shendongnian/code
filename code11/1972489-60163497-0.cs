    ServiceReference1.ServiceClient client = new ServiceClient();
                //logins account on the server side.
                client.ClientCredentials.Windows.ClientCredential.UserName = "administrator";
                client.ClientCredentials.Windows.ClientCredential.Password = "abcd1234!";
                Console.WriteLine(client.Test());
