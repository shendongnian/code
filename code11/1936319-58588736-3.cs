    static void Main(string[] args)
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        //by default, the nettcpbinding uses windows credential, we should provide server windows account.
        client.ClientCredentials.Windows.ClientCredential.UserName = "administrator";
        client.ClientCredentials.Windows.ClientCredential.Password = "abcd1234!";
        try
        {
            var result = client.GetData("Hello");
            Console.WriteLine(result);
        }
        catch (Exception)
        {
            throw;
        }    
    }
