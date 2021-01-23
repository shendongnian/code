    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        string cTheFile = HttpContext.Current.Request.Path;
        string sExtentionOfThisFile = System.IO.Path.GetExtension(cTheFile);
    
        if (sExtentionOfThisFile.Equals(".aspx", StringComparison.InvariantCultureIgnoreCase))
        {
            string acceptEncoding = MyCurrentContent.Request.Headers["Accept-Encoding"].ToLower();;
    
            if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
            {
                // defalte
                HttpContext.Current.Response.Filter = new DeflateStream(prevUncompressedStream,
                    CompressionMode.Compress);
                HttpContext.Current.Response.AppendHeader("Content-Encoding", "deflate");
            } else if (acceptEncoding.Contains("gzip"))
            {
                // gzip
                HttpContext.Current.Response.Filter = new GZipStream(prevUncompressedStream,
                    CompressionMode.Compress);
                HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
            }       
        }
    }
