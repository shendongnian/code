namespace SharpZure
{
    class SharpZure
    {
        static void Main(string[] args)
        {
            var graphClient = await Auth();
            UserData(graphClient);
            Console.ReadKey();
        }
        static async Task<GraphServiceClient> Auth()
        {
            var clientApp = PublicClientApplicationBuilder.Create(ConfigurationManager.AppSettings["clientId"]).Build();
            string[] scopes = new string[] { "user.read" };
            string token = null;
            var app = PublicClientApplicationBuilder.Create(ConfigurationManager.AppSettings["clientId"]).Build();
            var accounts = await app.GetAccountsAsync();
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes)
                                                   .ExecuteAsync();
            token = result.AccessToken;
            GraphServiceClient graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                            }));
            return graphClient;
        }
        static async Task UserData(GraphServiceClient graphClient)
        {
            Console.WriteLine("Display user details");
            var currentUser = await graphClient.Me.Request().GetAsync();
            Console.WriteLine(currentUser.DisplayName);
        }
    }
}
Simply return the Graph Client from Auth() and pass it to UserData().
