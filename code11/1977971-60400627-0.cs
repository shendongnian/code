cs
 private static async Task PrintUsersWithManager()
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithClientSecret(clientSecret)
                .Build();
            var token = await app.AcquireTokenForClient(new[] { ".default" }).ExecuteAsync();
            var graphServiceClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (message) =>
                    {
                        var result = await app.AcquireTokenForClient(new[] { ".default" }).ExecuteAsync();
                        message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.AccessToken);
                    }
                    )
                );
            var page = await graphServiceClient.Users.Request()
                .Expand(u => u.Manager)
                .GetAsync();
            var users = new List<User>();
            users.AddRange(page);
            while (page.NextPageRequest != null)
            {
                page = await page.NextPageRequest
                    .Expand(u => u.Manager)
                    .GetAsync();
                users.AddRange(page);
            }
            foreach (var item in users)
            {
                Console.WriteLine(JsonConvert.SerializeObject(new
                {
                    item.Id,
                    item.DisplayName,
                    item.Department,
                    Manager = item.Manager != null ? new
                    {
                        item.Manager.Id,
                        displayName = ((User)item.Manager).DisplayName
                    } : null
                }));
            }
        }
  [1]: https://www.nuget.org/packages/Microsoft.Graph.Beta/
  [2]: https://docs.microsoft.com/en-us/graph/query-parameters#expand-parameter
