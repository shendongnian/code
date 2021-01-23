    protected void Application_Error(Object sender, EventArgs e)
    {
      // At this point we have information about the error
      HttpContext ctx = HttpContext.Current;
    
      Exception exception = ctx.Server.GetLastError ();
    
      string errorInfo = 
         "<br>Offending URL: " + ctx.Request.Url.ToString () +
         "<br>Source: " + exception.Source + 
         "<br>Message: " + exception.Message +
         "<br>Stack trace: " + exception.StackTrace;
    
      ctx.Response.Write (errorInfo);
    
      // --------------------------------------------------
      // To let the page finish running we clear the error
      // --------------------------------------------------
      ctx.Server.ClearError ();
    }
