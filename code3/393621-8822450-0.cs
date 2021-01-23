    var FileSrvRelUrl = "/sub/doclib/Folder/File.doc";
    using (var fileStream = new MemoryStream(new byte[100]))
    {
        Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, FileSrvRelUrl, fileStream, false);
    }
    var web = clientContext.Web;
    var f = web.GetFileByServerRelativeUrl(FileSrvRelUrl);
    var item = f.ListItemAllFields;
    item["SomeField"] = "Value";
    item.Update();
    clientContext.Load(item, i=>i.Id);
    clientContext.ExecuteQuery();
