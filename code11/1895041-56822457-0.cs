    private void Application_BeginRequest(Object source, EventArgs e)
    {
        // wrong and dangerous
        HttpContext context = HttpContext.Current;
        context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
        HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip"); 
    }
