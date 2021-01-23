   protected void Application_BeginRequest(object sender, EventArgs e)
   {
       HttpContext context = HttpContext.Current;
       context.Response.Filter 
          = new GZipStream(context.Response.Filter, CompressionMode.Compress);
       context.Response.AppendHeader("Content-Encoding", "gzip");
       context.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
       // We can now set additional Vary headers...
       context.Response.Cache.VaryByHeaders.UserAgent = true;
       context.Response.Cache.VaryByHeaders["X-Requested-With"] = true;
   }
