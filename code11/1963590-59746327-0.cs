    ClientContext lClientContext = null;
    if (pSiteUrl.StartsWith(ConfigurationManager.AppSettings["New_URL"]))
    {
        lClientContext = SPOClientContext.GetAuthenticatedContext(pSiteUrl); // not sure what actually this is??
    }
    else
    {
        lClientContext = new ClientContext(pSiteUrl);
    }
    
    if (lClientContext != null)
    {
        Folder lRootFolder = lClientContext.Web.GetFolderByServerRelativeUrl(lUri.AbsolutePath + pFolderPath);
        lClientContext.Dispose();
    }
