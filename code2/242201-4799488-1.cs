    [WebMethod]
    public void Upload(byte[] contents, string filename)
    {
        File.WriteAllBytes(filename, contents);
    }
