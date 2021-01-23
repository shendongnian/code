    long FileL = (new FileInfo(filePath)).Length;
    byte[] bytes = new byte[1024*1024];
    response.Clear();
    response.ContentType = GetMimeType (System.IO.Path.GetFileName(filePath));
    response.AddHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(filePath));
    response.AddHeader("Content-Length", FileL.ToString());
    using (FileStream FS = File.OpenRead(filePath))
    {
    int bytesRead = 0;
    while ((bytesRead = FS.Read (bytes, 0, bytes.Length)) > 0 )
    {
    response.OutputStream.Write(bytes, 0, bytesRead);
    response.Flush();
    };
    response.Close();
    }
