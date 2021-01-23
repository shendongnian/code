   protected void Application_BeginRequest(object sender, EventArgs e)
   {
       HttpContext context = HttpContext.Current;
       context.Response.Filter 
          = new GZipStream(context.Response.Filter, CompressionMode.Compress);
       HttpContext.Current.Response.AppendHeader("Content-Encoding", "gzip");
       HttpContext.Current.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
       // We can now set additional Vary headers...
       HttpContext.Current.Response.Cache.VaryByHeaders.UserAgent = true;
       HttpContext.Current.Response.Cache.VaryByHeaders["X-Requested-With"] = true;
   }
