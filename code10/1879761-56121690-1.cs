    currentRunFolder.Files.Add(newFile);
    //currentRunFolder.Update();
    context.Load(newFile);
    context.ExecuteQuery();
    //newUrl = siteUrl + barRootFolderRelativeUrl + "/" + Path.GetFileName(@p);
    
    // Set document properties
    //Microsoft.SharePoint.Client.File uploadedFile = context.Web.GetFileByServerRelativeUrl(newUrl);
    ListItem listItem = newFile.ListItemAllFields;
    listItem["TestEQCode"] = "387074";
    listItem.Update();
    context.ExecuteQuery();
