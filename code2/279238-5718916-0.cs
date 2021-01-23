     void Application_Error(object sender, EventArgs e)
            {
                // Code that runs when an unhandled error occurs
                Exception ex = Server.GetLastError();
                ExceptionHandler.SendExceptionEmail(ex, "Unhandled", this.User.Identity.Name, this.Request.RawUrl);
                Response.Redirect("~/ErrorPage.aspx"); // So the user does not see the ASP.net Error Message
            }
