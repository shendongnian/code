    string siteUrl = "https://tenant.sharepoint.com/sites/lz";
    string userName = "lz@tenant.onmicrosoft.com";
    string password = "xxx";
    
    var securePassword = new SecureString();
    foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
    using (ClientContext clientContext = new ClientContext(siteUrl))
    {
    	clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
    	clientContext.RequestTimeout = -1;
    	var web = clientContext.Web;
    	clientContext.Load(web);
    	clientContext.ExecuteQuery();
    }
