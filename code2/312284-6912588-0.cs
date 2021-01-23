    // this method needs to be executed in background thread
    public String[] GetAttachments(ClientContext ctx, ListItem item)
    {
        // get the item's attachments folder
        Folder attFolder = ctx.Web.GetFolderByServerRelativeUrl( list.RootFolder.ServerRelativeUrl + "/Attachments/" + item.Id);
        FileCollection files = attFolder.Files;
        // I needed only urls, so I am loading just them
        ctx.Load(files, fs => fs.Include(f => f.ServerRelativeUrl));
        ctx.ExecuteQuery();
        
        // now you have collection of files (ctx.Site.Url is loaded a bit earlier ;) )
        return (from file in files select ctx.Site.Url + file.ServerRelativeUrl).ToArray();
    }
