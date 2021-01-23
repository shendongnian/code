        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {        
          // Fix for "Failed to Execute URL" when non-authenticated user 
          // browses to application root 
          if ((User == null) 
            && (string.Compare(Request.Url.AbsolutePath.TrimEnd('/'), 
            Request.ApplicationPath, true) == 0))
          {
            Response.Redirect(Request.ApplicationPath + "/Default.aspx");
            HttpContext.Current.ApplicationInstance.CompleteRequest();
          }
        }
