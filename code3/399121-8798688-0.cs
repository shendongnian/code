    public void getFile(fileId id) 
    {
        FileInfo fileInfo = GetFileInfo(id); //Your function, which returns File Info for the Id
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.TransmitFile(fileInfo.FullName);
        Response.ContentType = "CONTENT TYPE";
        Response.Flush();
    }
