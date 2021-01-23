    string filename = Path.Combine(Server.MapPath(rootPath), name);
    using (FileStream fs = new FileStream(filename, FileMode.CreateNew))
    {
        byte[] bytes = new byte[8192];
        int bytesRead;
        while ((bytesRead = Request.InputStream.Read(bytes, 0, bytes.Length)) > 0)
        {
            fs.Write(bytes, 0, bytesRead);
        }
    }
