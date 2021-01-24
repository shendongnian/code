    using (ClientContext clientContext = new ClientContext(ServerURL))
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        var securePassword = new SecureString();
        foreach (char c in password)
        {
            securePassword.AppendChar(c);
        }
        clientContext.Credentials = new SharePointOnlineCredentials(your_mail_ID, securePassword);
        Web web = clientContext.Web;
        var list = web.Lists.GetByTitle("your_list_name");
        clientContext.Load(list.RootFolder);
        clientContext.ExecuteQuery();
    }
