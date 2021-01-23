    // this method needs to be executed in background thread
    public String[] GetAttachments(ClientContext ctx, List list, ListItem item)
    {
        // these properties can be loaded in advance, outside of this method
        ctx.Load(list, l => l.RootFolder.ServerRelativeUrl);
        ctx.Load(ctx.Site, s=>s.Url);
        ctx.ExecuteQuery();
        // get the item's attachments folder 
        Folder attFolder = ctx.Web.GetFolderByServerRelativeUrl( list.RootFolder.ServerRelativeUrl + "/Attachments/" + item.Id);
        FileCollection files = attFolder.Files;
        // I needed only urls, so I am loading just them
        ctx.Load(files, fs => fs.Include(f => f.ServerRelativeUrl));
        ctx.ExecuteQuery();
        
        // now you have collection of files
        return (from file in files select ctx.Site.Url + file.ServerRelativeUrl).ToArray();
    }
