    namespace Demo1._0
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    await makeSoapCall();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    
            public async static void makeSoapCall()
            {
                EnventoryWebserviceClient client = new EnventoryWebserviceClient();
                client.ClientCredentials.UserName.UserName = "some@thing.com";
                client.ClientCredentials.UserName.Password = "somePass!";
    
                var method1 = await client.contentReportAsync();
                var method2 = await client.deleteSoapFlagsAsync();
                var method3 = await client.getSoapFlagsAsync();
            }
        }
    }
