    var users = await graphServiceClient.Users.Request().GetAsync();
            foreach (User user in users)
            {
                if (user.DisplayName.Equals("Tom"))
                {
                    var groupIds = await graphServiceClient.Users[user.UserPrincipalName].GetMemberGroups(false).Request().PostAsync();
                
                    var types = new List<string>() { "group" };
                    var groups = await graphServiceClient.DirectoryObjects
                                    .GetByIds(groupIds, types)
                                    .Request()
                                    .PostAsync();
                    foreach (var group in groups)
                    {
                       ....
                    }
                }
            }
