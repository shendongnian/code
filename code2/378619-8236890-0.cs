		protected void Application_Error(Object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError().InnerException;
			
			Application["Ex"] = ex;
			Response.Redirect("ErrorPage.aspx")
		}
