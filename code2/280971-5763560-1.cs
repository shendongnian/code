    private void GetThumbnailImage(HttpContext context, string fileName, int maxWidth, int maxHeight)
    {
    var data = new MemoryStream();
    using (var input = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        var buffer = new byte[input.Length];
        input.Read(buffer, 0, buffer.Length);
        data.Write(buffer, 0, buffer.Length);
        input.Close();
    }
    // reset position...
    data.Position = 0;
    MemoryStream ms = GetImageResized(
      data, maxWidth, maxHeight);
    context.Response.ContentType = "image/png";
    // output stream...
    context.Response.OutputStream.Write(ms.ToArray(), 0, (int)ms.Length);
    // Possible Caching
    //context.Response.Cache.SetCacheability(HttpCacheability.Public);
    //context.Response.Cache.SetExpires(DateTime.UtcNow.AddHours(2));
    //context.Response.Cache.SetETag(...);
    data.Dispose();
    ms.Dispose();
    }
  
