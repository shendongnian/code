    private CredentialCache GetCredential()
    {
        string url = @"https://telematicoprova.agenziadogane.it/TelematicoServiziDiUtilitaWeb/ServiziDiUtilitaAutServlet?UC=22&SC=1&ST=2";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        CredentialCache credentialCache = new CredentialCache();
        credentialCache.Add(new System.Uri(url), "Basic", new NetworkCredential(ConfigurationManager.AppSettings["ead_username"], ConfigurationManager.AppSettings["ead_password"]));
        return credentialCache;
    }
