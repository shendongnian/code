    There are three ways to handle exceptions in ASP.NET:
                   
                    1. All the exceptions will catch  page level.
                    2. All the exceptions will catch entire site level.
                    3. All the exceptions will catch by using "web.config" file
    Examples:
    =========
      **1.Exception Handling at page level.**
    
    
           public void Page_Error(object obj, EventArgs ergs)
            {
    
                Exception objErr = Server.GetLastError().GetBaseException();
                string err = "Error Caught in Application_Error event " +    
                             System.Environment.NewLine + "Error in: " + Request.Url.ToString() +
                             System.Environment.NewLine + "Error Occured Time:" + DateTime.Now +
                             System.Environment.NewLine + "Error Message:" + objErr.Message.ToString() +
                             System.Environment.NewLine + "Stack Trace:" + objErr.StackTrace.ToString();
                Response.Write(err);
                Server.ClearError();
                Response.Redirect("~/customError.aspx");
            }
    
    
      **2.Exception Handling at website level.**
         
    
        protected void Application_Error(object sender, EventArgs e)
            {
                Exception objErr = Server.GetLastError().GetBaseException();
                TraceExceptions objExceptionInsert = new  TraceExceptions();
                objExceptionInsert.StackTrace = objErr.StackTrace;
                objExceptionInsert.Exception = objErr.Message;
                objExceptionInsert.Page = Request.Url.AbsolutePath;
               //Inserting exception into the database
                int exceptioncode = Utilities.TraceException(objExceptionInsert);
                Server.ClearError();
               //Redirecting to common exception page
                string url = "~/Common/Exceptions.aspx?ExceptionCode=" + exceptioncode;
                Response.Redirect(url);
    
            }
    
      **3.Exception Handling at website level by using web.config.**
    
    The customErrors element of the web.config file is the last line of defense against an unhandled error. If you have other error handlers in place, like the Application_Error of Page_Error subs, these will get called first. Provided they don't do a Response.Redirect or a Server.ClearError, you should be brought to the page(s) defined in the web.config. In the web.config file, you can handle specific error codes (500, 404, etc), or you can use one page to handle all errors. This is a major difference between this method and the others (although you can emulate this by doing various Response.Redirects using the other methods). Open up your web.config file. The customErrors section uses this format:
    
    
    <customErrors defaultRedirect="url" mode="On|Off|RemoteOnly">
       <error statusCode="statuscode" redirect="url"/>
    </customErrors>
    
    Here is some important information about the "mode" attribute:
    "On" specifies that custom errors are enabled. If no defaultRedirect is specified, users see a generic error.
    
    "Off" specifies that custom errors are disabled. This allows display of detailed errors.
    
    "RemoteOnly" specifies that custom errors are shown only to remote clients, and ASP.NET errors are shown to the local host. This is the default.
    
    By default, the section looks like this when you create a Web application.
    
    
    <customErrors mode="RemoteOnly" 
    
    
    
     
    
                   
