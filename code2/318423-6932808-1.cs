      private const int MyMaxContentLength = 10000; //Wathever you want to accept as max file.
      protected void Application_BeginRequest(object sender, EventArgs e)
      {
         if (  Request.HttpMethod == "POST"
            && Request.ContentLength > MyMaxContentLength)
         {
            Response.Redirect ("~/errorFileTooBig.aspx");
         }
      }
