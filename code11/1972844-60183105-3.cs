    static void Main(string[] args)
            {
                ServiceReference1.ServiceClient client = new ServiceClient();
                client.ClientCredentials.Windows.ClientCredential.UserName = "administrator";
                client.ClientCredentials.Windows.ClientCredential.Password = "abcd1234!";
                var result = client.Test();
                Console.WriteLine(result);
    
            }
