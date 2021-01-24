        <%@ Application Language="C#" %>
        <script runat="server">
            void Application_Start(object sender, EventArgs e)
           {
               // Code that runs on application startup
           }
           void Application_End(object sender, EventArgs e)
           {
           //  Code that runs on application shutdown
           }
           void Session_Start(object sender, EventArgs e)
           {
           // Code that runs when a new session is started
           Session["ServerException"] = "";
           }
           void Session_End(object sender, EventArgs e)
           {
           // Code that runs when a session ends.
           // Note: The Session_End event is raised only when the sessionstate mode
           // is set to InProc in the Web.config file. If session mode is set to StateServer
           // or SQLServer, the event is not raised.
           }
	
           protected void Application_Error(Object sender, EventArgs e)
           {
           // Code that runs when an unhandled error occurs.
           // Get last error from the server
           Exception exc = Server.GetLastError();
           Session["ServerException"] = exc.InnerException.Message;
           Server.ClearError();
           Response.Clear();
           Response.Redirect("ErrorPageLog.aspx");
		  
           }
           </script>
