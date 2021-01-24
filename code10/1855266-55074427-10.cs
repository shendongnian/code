    static async Task GetDirectoryRolesInfo()
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
                int memberCount = 0;
                Console.WriteLine("Role Name = {0}", role.DisplayName);
                var members = graphServiceClient.DirectoryRoles[role.Id].Members.Request().GetAsync();
                memberCount = members.Result.Count;
                while (members.Result.NextPageRequest != null)
                {
                    // keep repeating above logic.. create a method etc. set membercount..
                }
                Console.WriteLine(memberCount.ToString());
            }
            while (roles.NextPageRequest != null)
            {
                // keep repeating above logic.. create a method etc..
            }
        }
