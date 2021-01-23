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
