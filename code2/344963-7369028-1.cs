    string siteUrl = "http://MyServer/sites/MySiteCollection";
    ClientContext clientContext = new ClientContext(siteUrl);
    Web web = clientContext.Web;
    clientContext.Load(web.Lists);
    clientContext.ExecuteQuery();
    List list = web.Lists["MyList"];
    RecursiveListFolder(list.RootFolder);
    
