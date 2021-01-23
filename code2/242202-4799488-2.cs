    [WebMethod]
    public void Upload(byte[] contents, string filename)
    {
        var appData = Server.MapPath("~/App_Data");
        var file = Path.Combine(appData, Path.GetFileName(filename));
        File.WriteAllBytes(file, contents);
    }
