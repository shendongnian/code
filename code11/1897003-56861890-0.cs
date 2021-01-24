    public void SaveBinaryDirect(ClientContext ctx, string libraryName, string filePath)
    {
        Web web = ctx.Web;
        // Ensure that target library exists, create if is missing
        if (!LibraryExists(ctx, web, libraryName))
        {
            CreateLibrary(ctx, web, libraryName);
        }
    
        List docs = ctx.Web.Lists.GetByTitle(libraryName);
        ctx.Load(docs, l => l.RootFolder);
        // Get the information about the folder that will hold the file
        ctx.Load(docs.RootFolder, f => f.ServerRelativeUrl);
        ctx.ExecuteQuery();
    
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, string.Format("{0}/{1}", docs.RootFolder.ServerRelativeUrl, System.IO.Path.GetFileName(filePath)), fs, true);
        }
    }
