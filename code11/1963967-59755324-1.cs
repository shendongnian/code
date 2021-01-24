    var user = await graphClient.Me.Request().GetAsync();
    var roles = await graphClient.Me.MemberOf.Request().GetAsync();
    foreach (var role in roles)
    {
        try{
        
            var id = role.Id;
            var assignments = await graphClient.DirectoryRoles.Request().Filter($"Id eq '{id}'").GetAsync();
            var groups = await graphClient.Groups.Request().Filter($"Id eq '{id}'").GetAsync();
            foreach (var assignment in assignments)
            {
                Console.WriteLine("Assigned Roles: " + assignment.DisplayName);
            }
        }
        catch(Exception ex)
        {
            continue;
        }
    }
