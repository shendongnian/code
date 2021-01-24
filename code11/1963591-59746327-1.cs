    public void DoSomething()
    {
        string pSiteUrl = "";
        string somePath = "";
        using (var lClientContext = CreateClientContext(pSiteUrl))
        {
            Folder lRootFolder = lClientContext.Web.GetFolderByServerRelativeUrl(somePath);
        }
    }
    private ClientContext CreateClientContext(string uri) =>
        uri.StartsWith(ConfigurationManager.AppSettings["New_URL"]) ? 
            SPOClientContext.GetAuthenticatedContext(uri) : 
            new ClientContext(uri);
