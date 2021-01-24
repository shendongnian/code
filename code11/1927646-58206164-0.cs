C#
	static async Task Main(string[] args)
        {
            var GraphClient = CreateGraphClient();
            User me = await GraphClient.Me.Request()
                            .WithUsernamePassword("user123@domain123.onmicrosoft.com", new NetworkCredential("", "MyPassword").SecurePassword)
                            .GetAsync();
            Console.WriteLine("OK:" + me.DisplayName);
            Console.ReadLine();
        }
        public static GraphServiceClient CreateGraphClient()
        {
            string clientId = "1234567-1234-1234-12345-1234567890";
            string tenantID = "domain123.onmicrosoft.com";
            IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
            .Create(clientId)
            .WithTenantId(tenantID)
            .Build();
            UsernamePasswordProvider authProvider = new UsernamePasswordProvider(publicClientApplication, null);
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            return graphClient;
        }
Another solution could be to make an application permission and then set access policy using PowerShell new-applicationaccesspolicy
https://docs.microsoft.com/en-us/powershell/module/exchange/organization/new-applicationaccesspolicy?view=exchange-ps
I have not tried that one yet, anyone know if this could help?
