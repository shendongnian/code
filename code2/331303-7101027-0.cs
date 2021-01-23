    var response = HttpContext.Current.Response;                
    string acceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"] ?? "";
    if (acceptEncoding.Contains("gzip"))
    {
        response.Filter =
            new System.IO.Compression.GZipStream(response.Filter,
                System.IO.Compression.CompressionMode.Compress);
        response.AppendHeader("Content-Encoding", "gzip");
    }
    else if (acceptEncoding.Contains("deflate"))
    {
        response.Filter =
            new System.IO.Compression.DeflateStream(response.Filter,
                System.IO.Compression.CompressionMode.Compress);
        response.AppendHeader("Content-Encoding", "deflate");
    }
