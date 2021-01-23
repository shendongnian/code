    public Boolean UploadDocument(String fileName, String filePath, List metaDataList)   
    {  
        SP.ClientContext ctx = new SP.ClientContext("http: //yoursharepointURL");  
        Web web = ctx.Web;  
        FileCreationInformation newFile = new FileCreationInformation();  
        newFile.Content = System.IO.File.ReadAllBytes(@"C: \TestFile.doc");  
        newFile.Url = " / " + fileName;  
        List docs = web.Lists.GetByTitle("Shared Documents");  
        Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);  
        context.Load(uploadFile);  
        context.ExecuteQuery();  
        SPClient.ListItem item = uploadFile.ListItemAllFields;  
        //Set the metadata  
        string docTitle = string.Empty;  
        item["Title"] = docTitle;  
        item.Update();  
        context.ExecuteQuery();  
    }
