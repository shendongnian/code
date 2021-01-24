    public static void DownloadStream(MemoryStream inputStream, string filename)
    {
        byte[] bytes = inputStream.ToArray();
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
        HttpContext.Current.Response.AddHeader("Content-Length", bytes.Length.ToString());
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.End(); // This is the key
    }
