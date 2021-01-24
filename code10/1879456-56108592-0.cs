        ClientContext clientContext=new ClientContext("http://sp/");
        ContentType cType = clientContext.Web.ContentTypes.GetById("0x0120D520A808");
       
        clientContext.Load(cType);
        clientContext.ExecuteQuery();
        
        try
        {
            if (!string.IsNullOrEmpty(cType.Name))
            {
                cType = clientContext.Web.ContentTypes.GetById("0x0120D520A808");
            }
            else
            {
                Console.WriteLine("Content Type not existed in current web.")
            }
        }
        catch (Microsoft.SharePoint.Client.ServerObjectNullReferenceException nullException)
        {
            cType = clientContext.Site.RootWeb.ContentTypes.GetById("0x0120D520");
        }
