    public void UploadXmlFile(string xmlContent, int orderNumber)
    {
        string filename = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + orderNumber + ".xml";
        ClientContext context = new ClientContext(absoluteHostUrl + relativeWebUrl);
        using (MemoryStream stream = new MemoryStream())
        {
            // use a MemoryStream for the file contents
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(xmlContent);
            // ... and upload it.
            Microsoft.SharePoint.Client.File.SaveBinaryDirect(
                context,
                "/" + relativeWebUrl + "Lists/" + libraryName + "/" + filename,
                stream,
                false);
        }
        // ...
