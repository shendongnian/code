    static async Task getDirectoryRolesUsingGraphServiceClient()
    {
            var graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage
                    .Headers
                    .Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                return Task.FromResult(0);
            }));
            var roles = await graphServiceClient.DirectoryRoles.Request().GetAsync();
            foreach (var role in roles)
            {
                Console.WriteLine("Role Name = {0}", role.DisplayName);
                var members = graphServiceClient.DirectoryRoles[role.Id].Members.Request().GetAsync();
                Console.WriteLine("Members count = {0}", members.Result.Count.ToString());
            }
    }
