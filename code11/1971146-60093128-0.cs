    var targetTenantUrl = "https://[tenant].sharepoint.com/";
    
    using (var context = new ClientContext(targetTenantUrl))
    {
        context.Credentials = OfficeDevPnP.Core.Utilities.CredentialManager.GetSharePointOnlineCredential("[Name-of-Your-Credentials]");
    
        // Create new "modern" team site at the url
        // https://[tenant].sharepoint.com/sites/mymodernteamsite
        var teamContext = await context.CreateSiteAsync(
            new TeamSiteCollectionCreationInformation
            {
                Alias = "mymodernteamsite", // Mandatory
                DisplayName = "displayName", // Mandatory
                Description = "description", // Optional
                Classification = "classification", // Optional
                IsPublic = true, // Optional, default true
            });
        teamContext.Load(teamContext.Web, w => w.Url);
        teamContext.ExecuteQueryRetry();
        Console.WriteLine(teamContext.Web.Url);
    }
