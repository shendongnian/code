    ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(new Uri("https://graph.windows.net/<tenantGuid>"),
    async () => await GetTokenForApplication());
    var servicePrincipal = activeDirectoryClient.ServicePrincipals.Where(x => x.AppId == "<applicationId>").ExecuteAsync().Result.CurrentPage[0];
    var appRoleAssignments = activeDirectoryClient.ServicePrincipals[servicePrincipal.ObjectId].AppRoleAssignedTo.ExecuteAsync().Result;
    int userCountForApp = 0;
    foreach(var appRoleAssignment in appRoleAssignments.CurrentPage)
    {
        if (appRoleAssignment.PrincipalType == "User")
        {
            userCountForApp++;
            Console.WriteLine("Role Id = {0} and User Name = {1}", appRoleAssignment.Id, appRoleAssignment.PrincipalDisplayName);
        }
    }
