        //Define a ClientContext with the specific Share Point site Url.
        var siteUrl="http://sp/sites/devtest";
        var folderUrl="/sites/devtest/Shared%20Documents";
        var ctx = new ClientContext(siteUrl);
        var folder = ctx.Web.GetFolderByServerRelativeUrl(folderUrl);
        //Get specific folder`s Url, where the target file exists.
        ctx.Load(folder, f => f.ServerRelativeUrl);
        ctx.ExecuteQuery();
        //Get file`s data.
        var targetFileName = "dsc_0520.jpg";
        var file = ctx.Web.GetFileByServerRelativeUrl(folder.ServerRelativeUrl +"/" +targetFileName);
        ctx.Load(file, f => f.Exists, f => f.Name,f=>f.CheckOutType);
        ctx.ExecuteQuery();
        //Output file data to ensure that we got exactly that file. That WriteLine provides required output without any errors.
        Console.WriteLine("File Data\n--> Exists: {0}\n--> Name: {1}",file.Exists,file.Name);
        //Try to Undo Check Out if the file.CheckOutType==CheckOutType.Online is true
        if(file.CheckOutType==CheckOutType.Online)
        {
            file.UndoCheckOut();
            ctx.ExecuteQuery();
            Console.WriteLine("Done");
        }
