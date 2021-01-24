        string password = "********";
        string account = "user@Tenant.onmicrosoft.com";
        var secret = new System.Security.SecureString();
        foreach (char c in password)
        {
            secret.AppendChar(c);
        }
        using (ClientContext ctx = new ClientContext("https://Tenant.sharepoint.com/sites/dev/"))
        {
            ctx.Credentials = new SharePointOnlineCredentials(account, secret);
            ctx.Load(ctx.Web);
            ctx.ExecuteQuery();
        }
