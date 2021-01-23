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
